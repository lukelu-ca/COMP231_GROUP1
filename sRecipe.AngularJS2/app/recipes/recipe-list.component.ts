import { Component, OnInit } from '@angular/core';
import { IRecipe } from './recipe';
import { RecipeFilterPipe } from './recipe-filter.pipe';
import { RecipeService } from './recipe.service';

@Component({
    selector: 'mm-recipes',
    templateUrl: 'app/recipes/recipe-list.component.html',
    pipes: [RecipeFilterPipe],
})

export class RecipeListComponent implements OnInit {
    pageTitle: string = 'Recipe List';
    imageWidth: number = 50;
    imageMargin: number = 2;
    seePoster: boolean = false;
    listFilter: string;
    errorMessage: string;

    recipes: IRecipe[];

    constructor(private _recipeService: RecipeService) {
    }

    toggleImage(): void {
        this.seePoster = !this.seePoster;
    }
    ngOnInit(): void {
        this._recipeService.getRecipes()
            .subscribe(recipes => this.recipes= recipes,
            error => this.errorMessage = <any>error);
    }
    onRatingClicked(message: string): void {
        this.pageTitle = 'Recipe List: ' + message;
    }

}
