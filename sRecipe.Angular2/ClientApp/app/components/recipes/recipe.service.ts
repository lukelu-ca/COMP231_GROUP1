import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../../AppSettings';

import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';

import { IRecipe } from './recipe';
import { IPicture } from './picture';

@Injectable()
export class RecipeService {
    private baseUrl = AppSettings.API_ENDPOINT + '/recipes';
    private baseUrlMealTypes = AppSettings.API_ENDPOINT + '/mealtypes';

    constructor(private http: Http) { }

    getMealTypes(): Observable<any[]> {
        return this.http.get(this.baseUrlMealTypes)
            .map((response: Response) => <any[]>(response.json() || {}))
            .do(data => console.log('getMealTypes: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getRecipes(): Observable<IRecipe[]> {
        return this.http.get(this.baseUrl)
            .map((response: Response) => <IRecipe[]>(response.json() || {}))
            .do(data => console.log('getRecipes: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getRecipe(id: number): Observable<IRecipe> {
        const url = `${this.baseUrl}/${id}`;
        return this.http.get(url)
            .map(this.extractData)
            .do(data => console.log('getRecipe: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    deleteRecipe(id: number): Observable<Response> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        const url = `${this.baseUrl}/${id}`;
        return this.http.delete(url, options)
            .do(data => console.log('deleteRecipe: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    saveRecipe(recipe: IRecipe): Observable<IRecipe> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        if (recipe.id === 0) {
            return this.createRecipe(recipe, options);
        }
        return this.updateRecipe(recipe, options);
    }

    private createRecipe(recipe: IRecipe, options: RequestOptions): Observable<IRecipe> {
        recipe.id = undefined;
        return this.http.post(this.baseUrl, recipe, options)
            .map(this.extractData)
            .do(data => console.log('createProduct: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private updateRecipe(recipe: IRecipe, options: RequestOptions): Observable<IRecipe> {
        const url = `${this.baseUrl}/${recipe.id}`;
        return this.http.put(url, recipe, options)
            .map(() => recipe)
            .do(data => console.log('updateProduct: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private extractData(response: Response) {
        let body = response.json();
        return body || {};
    }

    private handleError(error: Response): Observable<any> {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }


    uploadImage(recipeId: number,event: any): Observable<any> {
        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            let file: File = fileList[0];
            let formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            let headers = new Headers()

            //headers.append('Content-Type', 'json');  
            //headers.append('Accept', 'application/json');  
            let options = new RequestOptions({ headers: headers });
            let apiUrl1 = AppSettings.API_ENDPOINT + "/picture/" + recipeId;
            console.log(formData);
            return this.http.post(apiUrl1, formData, options)
                .map((response: Response) => <IPicture>response.json())
                .do(data => console.log("get All: " + JSON.stringify(data)))
                .catch(this.handleError)

        }
    }
  
}
