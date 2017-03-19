import {Component} from "@angular/core";


@Component({
    selector: "my-app",
    template: `
                <div>
                    <div class='container'>
                        <router-outlet></router-outlet>
                    </div>
                 </div>
                `
})

export class AppComponent {
    welcomeMessage: string = "Welcome to My .NET Angular 2 project!!";
    pageTitle: string = "The Premiere Movie Database";
}