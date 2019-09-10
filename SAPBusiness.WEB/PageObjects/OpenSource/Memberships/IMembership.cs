﻿namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public interface IMembership
    {
        string Description { get; }
        bool IconLink { get; }
        string Link { get; }
        string LinkText { get; }
        string Title { get; }
    }
}