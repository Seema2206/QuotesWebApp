using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarpDrivePractical.Data;
using WarpDrivePractical.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarpDrivePractical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDbContext _quotesDbContext;
        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }
        [HttpGet("GetQuotes")]
        public ActionResult GetQuotes()
        {
            List<Quotes> quotes = _quotesDbContext.Quotes.ToList();
            return Ok(MapQuoteVM(quotes));
        }
        [HttpGet("SearchQuotes")]
        public ActionResult SearchQuotes(string? author,string? tags,string? quote)
        {
            List<Quotes> quotes = new List<Quotes>();
            if(author != null)
            {
                quotes = _quotesDbContext.Quotes.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
            }
            else if(tags != null){
                quotes = _quotesDbContext.Quotes.Where(x => x.Tags == tags).ToList();
            }
            else if(quote != null)
            {
                quotes = _quotesDbContext.Quotes.Where(x => x.Quote.ToLower().Contains(quote.ToLower())).ToList();
            }
            return Ok(MapQuoteVM(quotes));
        }
        [HttpGet("GetQuote/{id}")]
        public ActionResult GetQuote(int id)
        {
            Quotes quotes = _quotesDbContext.Quotes.Where(x => x.Id == id).FirstOrDefault();
            return Ok(quotes);
        }

        [HttpPost("AddQuote")]
        public async Task<IActionResult> AddQuote([FromBody] QuotesVM quotes)
        {
            await _quotesDbContext.Quotes.AddAsync(MapQuote(quotes));
            await _quotesDbContext.SaveChangesAsync();
            return Ok("Quote Added Successfully");
        }
        [HttpPut("EditQuote/{Id}")]
        public async Task<IActionResult> EditQuote(int Id,[FromBody] QuotesVM quoteVM)
        {
            Quotes quote = MapQuote(quoteVM);
            quote.Id = Id;
            _quotesDbContext.Quotes.Update(quote);
            await _quotesDbContext.SaveChangesAsync();
            return Ok("Quote Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteQuote/{Id}")]
        public ActionResult DeleteQuote(int Id)
        {
            var quote = _quotesDbContext.Quotes.FirstOrDefault(x => x.Id == Id);
            if (quote == null)
            {
                return NotFound();
            }
            _quotesDbContext.Quotes.Remove(quote);
            _quotesDbContext.SaveChangesAsync();
            return Ok("Quote deleted Successfully");
        }
        private Quotes MapQuote(QuotesVM quotesVM)
        {
            Quotes quotes = new Quotes()
            {
                Author = quotesVM.Author,
                Tags = string.Join(",", quotesVM.Tags),
                Quote = quotesVM.Quote
            };
                
            return quotes;
        }
        private List<QuotesVM> MapQuoteVM(List<Quotes> quotes)
        {
            List<QuotesVM> QuotesVM = new List<QuotesVM>();
            foreach (var item in quotes)
            {
                QuotesVM quotesVm = new QuotesVM()
                {
                    Author = item.Author,
                    Tags = item.Tags.Split(","),
                    Quote = item.Quote
                };
                QuotesVM.Add(quotesVm);
            }
            return QuotesVM;
        }
    }
}

