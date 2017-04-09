import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { RecipeListComponent } from './recipe-list.component';
import { RecipeEditComponent } from './recipe-edit.component';
import { RecipeDetailComponent } from './recipe-detail.component';

import { RecipeDetailGuard, RecipeEditGuard } from './recipe-guard.service';

import { RecipeFilterPipe } from './recipe-filter.pipe';
import { RecipeService } from './recipe.service';

import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forChild([
            { path: 'recipes', component: RecipeListComponent },
            {
                path: 'recipe/:id',
                canActivate: [RecipeDetailGuard],
                component: RecipeDetailComponent
            },
            {
                path: 'recipeEdit/:id',
                canDeactivate: [RecipeEditGuard],
                component: RecipeEditComponent
            },
        ])
    ],
    declarations: [
        RecipeListComponent,
        RecipeEditComponent,
        RecipeDetailComponent,
        RecipeFilterPipe
    ],
    providers: [
        RecipeService,
        RecipeDetailGuard,
        RecipeEditGuard
    ]
})

export class RecipeModule { }