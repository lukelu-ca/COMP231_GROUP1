import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { RecipeListComponent } from './recipe-list.component';
import { RecipeDetailComponent } from './recipe-detail.component';

import { RecipeFilterPipe } from './recipe-filter.pipe';
import { RecipeService } from './recipe.service';
import { recipeRouting } from './recipe.routing';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        recipeRouting
    ],
    declarations: [
        RecipeListComponent,
        RecipeDetailComponent,
        RecipeFilterPipe
    ],
    providers: [
        RecipeService
    ]
})
export class RecipeModule { }