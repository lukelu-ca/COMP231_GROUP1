import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RecipeListComponent } from './recipe-list.component';
import { RecipeDetailComponent } from './recipe-detail.component';

export const recipeRoutes: Routes = [
    { path: 'recipes', component: RecipeListComponent },
    { path: 'recipe/:id', component: RecipeDetailComponent }
];

export const recipeRouting: ModuleWithProviders = RouterModule.forChild(recipeRoutes);