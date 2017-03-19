import { Injectable } from '@angular/core';
import { IRecipe } from './recipe';
import { IIngredient } from './ingredient';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class RecipeService {
    private _recipeUrl = 'http://localhost:9439/api/recipes';
    constructor(private _http: Http) { }

    getRecipes(): Observable<IRecipe[]> {
       return this._http.get(this._recipeUrl)
            .map((response: Response) => <IRecipe[]>response.json())
            .do(data => console.log("All: " + JSON.stringify(data)))
            .catch(this.handleError);
     }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    // added for routing
    getRecipe(id: number): Observable<IRecipe> {
        return this.getRecipes()
            .map((recipes: IRecipe[]) => recipes.find(m => m.id === id));
    }

}
