﻿using Core.WebDriver;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class SummaryProgress : BasePageObject, ISummaryProgress
    {
        public SummaryProgress(WebDriver driver) : base(driver)
        {
        }

        private IWebElement ElementPercentage
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tutorialSummary .value"));
            }
        }
        public int Value
        {
            get
            {
                return int.Parse(ElementPercentage.Text);
            }
        }

        private IWebElement ProgressBar
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tutorialSummary .bar"));
            }
        }

        public double GetBarProgress()
        {
            var transformValue = ProgressBar.GetCssValue("transform");

            var matches = Regex.Matches(transformValue, @"(-?\d+\.?\d+|\d+)");
            var a = double.Parse(matches[0].Value);
            var b = double.Parse(matches[1].Value);

            var actualResult = Math.Round(Math.Atan2(b, a) * (180 / Math.PI), 2) + 360;

            return actualResult;
        }

        public double GetProgress()
        {
            return (double)Value * 360 / 100;
        }
    }
}
