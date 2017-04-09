import { Component, OnInit } from '@angular/core';

import { IRecipe } from './recipe';
import { RecipeService } from './recipe.service';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'recipe-list',
    template: require('./recipe-list.component.html'),
})

export class RecipeListComponent implements OnInit {
    pageTitle: string = 'Recipe List';
    imageWidth: number = 50;
    imageMargin: number = 2;
    showImage: boolean = true;
    onlyPublic: boolean = false;
    listFilter: string;
    errorMessage: string;

    recipes: IRecipe[];
    private sub: Subscription;

    constructor(private recipeService: RecipeService) {

    }

    togglePublic(): void {
        this.onlyPublic = !this.onlyPublic;
    }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void {
        this.sub = this.recipeService.getRecipes()
            .subscribe(recipes => this.recipes = recipes,
            error => this.errorMessage = <any>error);
    }


}
