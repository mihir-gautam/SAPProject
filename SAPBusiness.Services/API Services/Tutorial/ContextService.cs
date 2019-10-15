﻿using Newtonsoft.Json;
using RestSharp;
using SAPBusiness.Configuration;
using SAPBusiness.MiniNavigator;
using SAPBusiness.TutorialData;
using System.Net;

namespace SAPBusiness.Services.API_Services.Tutorial
{
    public class ContextService : IContextService
    {
        private static readonly string resourseUrlBefore = "/bin/sapdxc/tutorial/miniNavigator";
        private static readonly string resourseUrlAfter = "/content/developers/website/languages/en/tutorials/cp-apim-openconnectors-enable.json";

        private readonly IEnvironmentConfig _appConfiguration;

        public ContextService(IEnvironmentConfig appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        private TutorialResponse GetMiniNavigatorContext(TutorialQuery tutorialQuery)
        {
            string requestUrl = string
                .Concat(resourseUrlBefore, $".{tutorialQuery.TutorialId}.mission.{tutorialQuery.MissionId}.json", resourseUrlAfter);

            var client = new RestClient(_appConfiguration.ProdUrl);

            var request = new RestRequest(requestUrl, Method.GET);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TutorialResponse>(response.Content);
            }
            else
            {
                throw new WebException($"Mission was not recieved. HttpStatusCode: {response.StatusCode}");
            }
        }

        public Mission GetMission(TutorialQuery tutorialQuery)
        {
            return GetMiniNavigatorContext(tutorialQuery).Context.Mission;
        }

        public NextStep GetNextStep(TutorialQuery tutorialQuery)
        {
            return GetMiniNavigatorContext(tutorialQuery).Steps.NextStep;
        }
    }
}
