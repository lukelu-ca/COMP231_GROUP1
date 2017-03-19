import { PipeTransform, Pipe } from '@angular/core';
import { IRecipe } from './recipe';

@Pipe({
    name: 'recipeFilter'
})
export class RecipeFilterPipe implements PipeTransform {

    transform(value: IRecipe[], filter: string): IRecipe[] {
        filter = filter ? filter.toLocaleLowerCase() : null;
        return filter ? value.filter((recipe: IRecipe) =>
            recipe.name.toLocaleLowerCase().indexOf(filter) != -1) : value;
    }

}
