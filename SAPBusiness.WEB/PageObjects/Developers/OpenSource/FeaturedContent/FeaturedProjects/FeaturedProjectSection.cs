﻿namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.FeaturedProjects
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class FeaturedProjectSection : BasePageObject, IFeaturedProjectSection
    {
        public FeaturedProjectSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string Icon
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .icon")).GetAttribute("url");
            }
        }

        public string Title
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .header-title")).Text;
            }
        }

        public string Topic
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .header-topic")).Text;
            }
        }

        public string Description
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .description-container")).Text;
            }
        }

        public string ViewAllLink
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .description-container a[href]")).Text;
            }
        }

        public string TitleLink
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .header-title")).GetAttribute("href");
            }
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
