﻿namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITileElement
    {
        string Description { get; }
        string Experience { get; }
        string Title { get; }
        string TagLink { get; }
        string PrimaryTag { get; }

        bool BookMarkDisplayed();

        bool HasLicenseKey();
    }
}