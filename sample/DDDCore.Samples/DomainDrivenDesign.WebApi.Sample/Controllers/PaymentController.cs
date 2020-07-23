namespace DomainDrivenDesign.WebApi.Sample.Controllers
{
    using DomainDrivenDesign.Application.Sample.Command;
    using DomainDrivenDesign.Core.CQRS.Interface;
    using DomainDrivenDesign.WebApi.Sample.ViewModel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Railway.NetCore.Core;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        protected IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Process payment
        /// </summary>
        /// <param name="paymentRequest">payment Request</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ProcessPayment(PaymentRequest paymentRequest)
        {
            return ProcessCardPaymentCommand
                                    .Create(
                                                paymentRequest.Card.CardNumber,
                                                paymentRequest.Card.CVV,
                                                paymentRequest.Card.ExpirationDate,
                                                paymentRequest.Amount,
                                                paymentRequest.Currency,
                                                paymentRequest.BeneficiaryAlias
                                            )
                                    .OnSuccess(processCardPaymentCommand => _mediator.Publish(processCardPaymentCommand))
                                    .OnBoth(error=> error.IsFailure ? Ok() : Ok());
        }
    }
}
