import { Component } from '@angular/core';

@Component({
    selector: 'home',
    template: require('./home.component.html')
})
export class HomeComponent {
    public pageTitle: string = 'Home';
    private LOGO1 = require('./assets/teamwork.jpg');
    private LOGO2 = require('./assets/books.jpg');
    private LOGO3 = require('./assets/theme.png');

}
