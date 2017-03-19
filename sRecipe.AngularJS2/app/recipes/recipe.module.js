"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var recipe_list_component_1 = require("./recipe-list.component");
var recipe_detail_component_1 = require("./recipe-detail.component");
var recipe_filter_pipe_1 = require("./recipe-filter.pipe");
var recipe_service_1 = require("./recipe.service");
var recipe_routing_1 = require("./recipe.routing");
var RecipeModule = (function () {
    function RecipeModule() {
    }
    return RecipeModule;
}());
RecipeModule = __decorate([
    core_1.NgModule({
        imports: [
            common_1.CommonModule,
            forms_1.FormsModule,
            recipe_routing_1.recipeRouting
        ],
        declarations: [
            recipe_list_component_1.RecipeListComponent,
            recipe_detail_component_1.RecipeDetailComponent,
            recipe_filter_pipe_1.RecipeFilterPipe
        ],
        providers: [
            recipe_service_1.RecipeService
        ]
    })
], RecipeModule);
exports.RecipeModule = RecipeModule;
//# sourceMappingURL=recipe.module.js.map