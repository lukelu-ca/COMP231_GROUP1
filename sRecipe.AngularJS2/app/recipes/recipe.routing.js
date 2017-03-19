"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var recipe_list_component_1 = require("./recipe-list.component");
var recipe_detail_component_1 = require("./recipe-detail.component");
exports.recipeRoutes = [
    { path: 'recipes', component: recipe_list_component_1.RecipeListComponent },
    { path: 'recipe/:id', component: recipe_detail_component_1.RecipeDetailComponent }
];
exports.recipeRouting = router_1.RouterModule.forChild(exports.recipeRoutes);
//# sourceMappingURL=recipe.routing.js.map