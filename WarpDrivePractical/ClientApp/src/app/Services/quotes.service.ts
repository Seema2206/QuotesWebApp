import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Quotes } from '../models/quotes.model';

@Injectable({
  providedIn: 'root'
})
export class QuotesService {

  constructor(private http: HttpClient) { }
  getAllQuotes(): Observable<any> {
    return this.http.get<Quotes[]>('https://localhost:7174/api/Quotes/getQuotes');
  }
  addQuote(quote: Quotes) {
    quote.id = "0";
    return this.http.post('https://localhost:7174/api/Quotes/AddQuote', quote);
  }
  getQuote(id: string): Observable<Quotes> {
    return this.http.get<Quotes>('https://localhost:7174/api/Quotes/getQuote/' + id);
  }
  updateQuote(quote: Quotes): Observable<Quotes> {
    return this.http.post<Quotes>('https://localhost:7174/api/Quotes/EditQuote', quote);
  }
  deleteQuote(id: string): Observable<Quotes> {
    return this.http.delete<Quotes>('https://localhost:7174/api/Quotes/deleteQuote/' + id);
  }
}
