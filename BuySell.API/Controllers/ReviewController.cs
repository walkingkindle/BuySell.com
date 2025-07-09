using BuySell.API.Extensions;
using BuySellDotCom.Application.Interfaces.Services;
using BuySellDotCom.Application.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.API.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController(IReviewService reviewService): ControllerBase
    {
        public async Task<IActionResult> CreateReview(ReviewDto dto)
        {
            var result = await reviewService.CreateReview(dto);

            return result.ToActionResult();

        }


    }
}
