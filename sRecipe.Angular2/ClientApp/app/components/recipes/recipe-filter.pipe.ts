import { PipeTransform, Pipe } from '@angular/core';
import { IRecipe } from './recipe';

@Pipe({
    name: 'recipeFilter'
})
export class RecipeFilterPipe implements PipeTransform {

    transform(value: IRecipe[], filterBy: string, showPublicOnly: boolean): IRecipe[] {
        filterBy = filterBy ? filterBy.toLocaleLowerCase() : null;
        var list= filterBy ? value.filter((recipe: IRecipe) =>
            (recipe.name + recipe.mealTypeName).toLocaleLowerCase().indexOf(filterBy) !== -1) : value;
        if (showPublicOnly)
            list = list.filter((recipe: IRecipe) => recipe.isPublic == true);
        return list;
    }
}
