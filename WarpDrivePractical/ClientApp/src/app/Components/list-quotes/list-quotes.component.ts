import { Component, OnInit } from '@angular/core';
import { Quotes } from 'src/app/models/quotes.model';
import { Route, Router } from '@angular/router';
import { QuotesService } from 'src/app/services/quotes.service';

@Component({
  selector: 'app-list-quotes',
  templateUrl: './list-quotes.component.html',
  styleUrls: ['./list-quotes.component.css']
})
export class ListQuotesComponent implements OnInit {
  quotes: Quotes[] = [];
  constructor(private quotesService: QuotesService, private router: Router) { }
  ngOnInit(): void {
    this.quotesService.getAllQuotes()
      .subscribe({
        next: (response) => {
          this.quotes = response;
          console.log(this.quotes);
        },
        error: (resonse) => {
          console.log(resonse);
        }
      })
  }
  deleteQuote(id: string) {
    this.quotesService.deleteQuote(id)
      .subscribe({
        next: (response) => {
          window.location.reload();
        }
      });
  }
}
