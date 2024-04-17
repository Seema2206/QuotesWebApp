import { Component } from '@angular/core';
import { Quotes } from 'src/app/models/quotes.model';

@Component({
  selector: 'app-manage-quotes',
  templateUrl: './manage-quotes.component.html',
  styleUrls: ['./manage-quotes.component.css']
})
export class ManageQuotesComponent {
  quotes: Quotes = {
    id: '',
    author: 'seema',
    tags: '',
    quote: ''
  }
}
