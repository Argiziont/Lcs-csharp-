using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseAndLogic.Logic;
using LCS_Web_.Models;
using LCS_Web_.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LCS_Web_.Controllers
{
    public class LcsStringController : Controller
    {
        //our dependency injected interface
        private ILscString repository;
        public LcsStringController(ILscString repository)
        {
            this.repository = repository;
        }
        //first output
        [HttpGet]
        public IActionResult LcsForm()
        {
            ViewBag.IsAnwerReady = false;
            return View(new LcsHolder { Strings= repository.LastElements(5) });
        }
        [HttpPost]
        public IActionResult LcsForm(LcsHolder answerInput)
        {
            if (ModelState.IsValid)
            {//adding info from form to the 
                repository.AddElement(new Lcs { 
                    FirstString = answerInput.First, 
                    SecondString = answerInput.Second, 
                    AnswerString = answerInput.Answer });
                //reseting output and setuping new elements
                answerInput.Strings = repository.LastElements(5);
                ViewBag.IsAnwerReady = true;
                return View(answerInput);
            }
            else
            {
                ViewBag.IsAnwerReady = false;
                return View(new LcsHolder { Strings = repository.LastElements(5) });
            }
        }
    }
}