using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcCookieAuthSample.ViewModels;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using MvcCookieAuthSample.Services;

namespace MvcCookieAuthSample.Controllers
{
    public class ConsentController : Controller
    {
        private readonly ConsentService _consentService;

        public ConsentController(ConsentService consentService)
        {
            _consentService = consentService;
        }       

        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl, InputConsentViewModel viewModel = null)
        {
            var model = await _consentService.BuildConsentViewModel(returnUrl, viewModel);
            if(model == null)
            {

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(InputConsentViewModel viewModel)
        {
            var result = await _consentService.ProcessConsent(viewModel);
            if(result.IsRedirect)
            {
                return Redirect(result.RedirectUrl);
            }

            if(!string.IsNullOrEmpty(result.ValidationError))
            {
                ModelState.AddModelError(" ", result.ValidationError);
            }

            return View(result.consentViewModel);
        }
    }

}