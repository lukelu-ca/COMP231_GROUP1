import { Component, OnInit, AfterViewInit, OnDestroy, ViewChildren, ElementRef } from '@angular/core';
import { FormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/merge';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

import { IRecipe } from './recipe';
import { RecipeService } from './recipe.service';
import { AppSettings } from '../../AppSettings';

import { NumberValidators } from '../shared/number.validator';
import { GenericValidator } from '../shared/generic-validator';

@Component({
    selector: 'recipe-edit',
    template: require('./recipe-edit.component.html')
})
export class RecipeEditComponent implements OnInit, AfterViewInit, OnDestroy {
    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    pageTitle: string = 'Recipe Edit';
    errorMessage: string;
    recipeForm: FormGroup;
    mealTypes: any[];
    recipe: IRecipe;
    private sub: Subscription;

    // Use with the generic validation message class
    displayMessage: { [key: string]: string } = {};
    private validationMessages: { [key: string]: { [key: string]: string } };
    private genericValidator: GenericValidator;

    //get tags(): FormArray {
    //    return <FormArray>this.recipeForm.get('tags');
    //}

    constructor(private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private recipeService: RecipeService) {

        // Defines all of the validation messages for the form.
        // These could instead be retrieved from a file or database.
        this.validationMessages = {
            name: {
                required: 'Recipe name is required.',
                minlength: 'Recipe name must be at least 3 characters.',
                maxlength: 'Recipe name cannot exceed 50 characters.'
            },
            cooking_Time: {
                required: 'Cooking time is required.',
                range: 'Cooking time between 1 (lowest) and 300 (highest)'
            },
            number_of_Services: {
                required: 'Number of Services is required.',
                range: 'Number of Services time between 1 (lowest) and 30 (highest)'
            },
            calorie: {
                required: 'Carlorie is required.',
                range: 'Carlorie between 1 (lowest) and 3000 (highest)'
            },
            mealTypeId: {
                required: 'Meal Type is required.'
            }
        };

        // Define an instance of the validator for use with this form, 
        // passing in this form's set of validation messages.
        this.genericValidator = new GenericValidator(this.validationMessages);
    }

    ngOnInit(): void {
        this.recipeForm = this.fb.group({
            name: ['', [Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50)]],
            cooking_Time: ['', [Validators.required,
            NumberValidators.range(0, 300)
            ]],
            number_of_Services: ['', [Validators.required,
            NumberValidators.range(0, 30)
            ]],
            calorie: ['', [Validators.required,
            NumberValidators.range(0, 3000)
            ]],
            mealTypeId: ['', [Validators.required]],
            isPublic: ['']
        });

        this.getMealTypes();

        // Read the product Id from the route parameter
        this.sub = this.route.params.subscribe(
            params => {
                let id = +params['id'];
                this.getRecipe(id);
            }
        );
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    ngAfterViewInit(): void {
        // Watch for the blur event from any input element on the form.
        let controlBlurs: Observable<any>[] = this.formInputElements
            .map((formControl: ElementRef) => Observable.fromEvent(formControl.nativeElement, 'blur'));

        // Merge the blur event observable with the valueChanges observable
        Observable.merge(this.recipeForm.valueChanges, ...controlBlurs).debounceTime(300).subscribe(value => {
            this.displayMessage = this.genericValidator.processMessages(this.recipeForm);
        });
    }

    //addTag(): void {
    //    this.tags.push(new FormControl());
    //}
    getMealTypes(): void {
        this.recipeService.getMealTypes()
            .subscribe(
            (mealtypes: any[]) => this.mealTypes = mealtypes,
            (error: any) => this.errorMessage = <any>error
            );
    }

    getRecipe(id: number): void {
        this.recipeService.getRecipe(id)
            .subscribe(
            (recipe: IRecipe) => this.onRecipeRetrieved(recipe),
            (error: any) => this.errorMessage = <any>error
            );
    }

    onRecipeRetrieved(recipe: IRecipe): void {
        if (this.recipeForm) {
            this.recipeForm.reset();
        }
        this.recipe = recipe;

        if (this.recipe.id === 0) {
            this.pageTitle = 'Add Recipe';
        } else {
            this.pageTitle = `Edit Recipe: ${this.recipe.name}`;
        }

        // Update the data on the form
        this.recipeForm.patchValue({
            name: this.recipe.name,
            cooking_Time: this.recipe.cooking_Time,
            number_of_Services: this.recipe.number_of_Services,
            mealTypeId: this.recipe.mealTypeId,
            calorie: this.recipe.calorie,
            isPublic: this.recipe.isPublic
            //productName: this.recipe.productName,
            //productCode: this.recipe.productCode,
            //starRating: this.recipe.starRating,
            //description: this.recipe.description
        });
        //this.recipeForm.setControl('tags', this.fb.array(this.recipe.tags || []));
    }

    deleteRecipe(): void {
        if (this.recipe.id === 0) {
            // Don't delete, it was never saved.
            this.onSaveComplete();
        } else {
            if (confirm(`Really delete the product: ${this.recipe.name}?`)) {
                this.recipeService.deleteRecipe(this.recipe.id)
                    .subscribe(
                    () => this.onSaveComplete(),
                    (error: any) => this.errorMessage = <any>error
                    );
            }
        }
    }

    saveRecipe(): void {
        if (this.recipeForm.dirty && this.recipeForm.valid) {
            // Copy the form values over the product object values
            let p = Object.assign({}, this.recipe, this.recipeForm.value);
            if (p.userID == 0) p.userId = 1;
            p.postTime = Date.now;
            this.recipeService.saveRecipe(p)
                .subscribe(
                () => this.onSaveComplete(),
                (error: any) => this.errorMessage = <any>error
                );
        } else if (!this.recipeForm.dirty) {
            this.onSaveComplete();
        }
    }

    onSaveComplete(): void {
        // Reset the form to clear the flags
        this.recipeForm.reset();
        this.router.navigate(['/recipes']);
    }

    updateImage(data: any) {
        console.log(data);
        this.recipe.pictureId = data.id;
        this.recipe.links[1].href = AppSettings.API_ENDPOINT + '/picture/' + data.id;

    }

    uploadImage(event: any) {
        this.recipeService.uploadImage(this.recipe.id, event)
            .subscribe(
            data => this.updateImage(data),
            err => console.log('error:', err)
            );
    }

}
