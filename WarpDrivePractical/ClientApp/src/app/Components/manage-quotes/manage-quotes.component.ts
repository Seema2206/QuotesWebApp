import { Component,OnInit } from '@angular/core';
import { Quotes } from 'src/app/models/quotes.model';
import { QuotesService } from 'src/app/services/quotes.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-manage-quotes',
  templateUrl: './manage-quotes.component.html',
  styleUrls: ['./manage-quotes.component.css']
})
export class ManageQuotesComponent {
  tags: string = '';
  quotes: Quotes = {
    id: '',
    author: 'seema',
    tags: [''],
    quote: ''
  }
  constructor(private quotesService: QuotesService, private router: Router) { }

  addQuotes() {
  this.quotes.tags = this.tags.split(',');
    console.log(this.quotes);
    this.quotesService.addQuote(this.quotes)
      .subscribe({
        next: (response) => {
          console.log(response)
          this.router.navigate(['']);
        }
      });
  }
}
