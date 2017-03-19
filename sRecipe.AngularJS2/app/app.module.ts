import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';

import { HttpModule } from '@angular/http';
import { routing } from './app.routing';
import { WelcomeComponent } from './home/welcome.component';
import { MovieModule } from './movies/movie.module';
import { RecipeModule } from './recipes/recipe.module';

@NgModule({
    imports: [MovieModule, RecipeModule, BrowserModule, FormsModule, HttpModule, routing],
    declarations: [AppComponent, WelcomeComponent],
    bootstrap: [AppComponent]

})
export class AppModule { }
