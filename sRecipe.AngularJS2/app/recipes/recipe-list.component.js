"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var recipe_filter_pipe_1 = require("./recipe-filter.pipe");
var recipe_service_1 = require("./recipe.service");
var RecipeListComponent = (function () {
    function RecipeListComponent(_recipeService) {
        this._recipeService = _recipeService;
        this.pageTitle = 'Recipe List';
        this.imageWidth = 50;
        this.imageMargin = 2;
        this.seePoster = false;
    }
    RecipeListComponent.prototype.toggleImage = function () {
        this.seePoster = !this.seePoster;
    };
    RecipeListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._recipeService.getRecipes()
            .subscribe(function (recipes) { return _this.recipes = recipes; }, function (error) { return _this.errorMessage = error; });
    };
    RecipeListComponent.prototype.onRatingClicked = function (message) {
        this.pageTitle = 'Recipe List: ' + message;
    };
    return RecipeListComponent;
}());
RecipeListComponent = __decorate([
    core_1.Component({
        selector: 'mm-recipes',
        templateUrl: 'app/recipes/recipe-list.component.html',
        pipes: [recipe_filter_pipe_1.RecipeFilterPipe],
    }),
    __metadata("design:paramtypes", [recipe_service_1.RecipeService])
], RecipeListComponent);
exports.RecipeListComponent = RecipeListComponent;
//# sourceMappingURL=recipe-list.component.js.map