﻿/// <author>Rupesh Kumar</author>
/// <summary>
/// Unit Test for Dashboard View Model 
/// </summary>


using Dashboard;
using PlexShareDashboard.Dashboard.Server.Telemetry;
using PlexShareDashboard.Dashboard.UI.ViewModel;
using System.ComponentModel;

namespace PlexShareTests.DashboardTests.UI
{
    public class DashboardViewModelsUnitTests
    {
        private DashboardViewModel DashboardViewModelForTest = new(1);


        /// <summary>
        ///first doing the set up for testing purpose
        /// </summary>
        
        [Fact]
        public void SetUpTest()
        {
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }
            
        
            
            Assert.NotNull(DashboardViewModelForTest);
            Assert.IsType<DashboardViewModel>(DashboardViewModelForTest);
            Assert.NotNull(DashboardViewModelForTest.GetClientSessionManager());
            Assert.NotNull(DashboardViewModelForTest.GetSessionData());
            Assert.NotNull(DashboardViewModelForTest.GetSessionAnalytics());
            Assert.NotNull(DashboardViewModelForTest.ParticipantsList);
            Assert.NotNull(DashboardViewModelForTest.UserCountList);
            Assert.NotNull(DashboardViewModelForTest.ChatCountListForUserId);
            Assert.NotNull(DashboardViewModelForTest.ChatCountListForUserName);
            Assert.NotNull(DashboardViewModelForTest.UserIdList);
            Assert.NotNull(DashboardViewModelForTest.TimeStampsList);

        }



        [Fact]
        /// <summary>
        ///writing the testing for checking the initialization process 
        /// </summary>
        public void Initialization_Test_Of_Lists()
        {
            //we have to test the initialisation of the list  
            Assert.Empty(DashboardViewModelForTest.ParticipantsList);
            Assert.Empty(DashboardViewModelForTest.UserCountList);
            Assert.Empty(DashboardViewModelForTest.UserIdList);
            Assert.Empty(DashboardViewModelForTest.TimeStampsList);
            Assert.Empty(DashboardViewModelForTest.ChatCountListForUserId);
            Assert.Empty(DashboardViewModelForTest.ChatCountListForUserName);

            //say everything went fine 
            return;
        }


        /// <summary>
        ///testing function for testing the initialization of the variables 
        /// </summary>
        [Fact]
        public void Initialization_Test_Of_Variables()
        {
            Assert.Equal(100, DashboardViewModelForTest.AttentiveUsersSetter);
            Assert.Equal(0, DashboardViewModelForTest.NonAttentiveUsersSetter);
            Assert.Equal(1, DashboardViewModelForTest.TotalParticipantsCountSetter);
            Assert.Equal(0, DashboardViewModelForTest.TotalMessageCountSetter);
            Assert.Equal("0", DashboardViewModelForTest.EngagementRateSetter);
            Assert.Equal("LabMode", DashboardViewModelForTest.SessionModeSetter);
            Assert.Equal(0, DashboardViewModelForTest.SessionScoreSetter);
            Assert.Equal("Switch Mode", DashboardViewModelForTest.ButtonContentSetter);

            //say everything went fine 
            return;
        }




        [Fact]
        /// <summary>
        ///function to test the on property change event whether it is triggering or not 
        /// </summary>
        public void OnPropertyChange_Event_Test()
        {
            string CheckCurrentProperty = DashboardViewModelForTest.EngagementRateSetter;
            DashboardViewModelForTest.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                CheckCurrentProperty = e.PropertyName;

            };

            DashboardViewModelForTest.OnPropertyChanged("EngagementRateSetter");

            Assert.NotNull(CheckCurrentProperty);
            Assert.Equal("EngagementRateSetter", CheckCurrentProperty);

            //say everything went fine 
            return;
        
        }



        [Fact]
        /// <summary>
        ///function to check the updatebutton setter 
        /// </summary>
        public void UpdateButtonContent_Test_To_Update_According_To_Current_Mode()
        {
            //DashboardViewModelForTest.ButtonContentSetter = "LabMode";
            DashboardViewModelForTest.SessionModeSetter = "LabMode";

          

            DashboardViewModelForTest.UpdateButtonContent();

            Assert.Equal("Switch To ExamMode", DashboardViewModelForTest.ButtonContentSetter);

            //say everything went fine 
            return;
        }




        [Fact]
        /// <summary>
        ///writing the function to test the update participant list 
       /// </summary>
        public void UpdateParticipantsList_Test()
        {
            //new System.Windows.Application();
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }

            List<UserData> newParticipantsList = new List<UserData>();
            UserData user1 = new UserData("Rupesh kumar", 1);
            UserData user2 = new UserData("Saurabh Kumar", 2);
            UserData user3 = new UserData("Hrishi Raaj", 3);

            newParticipantsList.Add(user1);
            newParticipantsList.Add(user2);
            newParticipantsList.Add(user3);

            DashboardViewModelForTest.UpdateParticipantsList(newParticipantsList);

            Assert.Equal("Rupesh kumar  (Instructor)", DashboardViewModelForTest.ParticipantsList[0].UserName);
            Assert.Equal("Saurabh Kumar", DashboardViewModelForTest.ParticipantsList[1].UserName);
            Assert.Equal("Hrishi Raaj", DashboardViewModelForTest.ParticipantsList[2].UserName);
            Assert.Equal(3, DashboardViewModelForTest.ParticipantsList.Count);

            //say everything went fine 
            return;
        }




        [Fact]
        /// <summary>
        ///function to test the GetHourAndMinute
        /// </summary>
        public void GetHourAndMinute_Test()
        {

            DateTime currTime1 = new DateTime(2021, 11, 23, 1, 15, 0);

            string stringFormat = DashboardViewModelForTest.GetHourAndMinute(currTime1);

            Assert.Equal("01:15", stringFormat);

            //say everything went fine 
            return;
        }




        [Fact]
        /// <summary>
        /// testing function to test the updateUserCountVsTimeStamp Calculations 
        /// </summary>
        public void UpdateUserCountVsTimeStamp_Test()
        {
            //new System.Windows.Application();
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }

            DateTime currDateTime1 = new DateTime(2021, 11, 23, 1, 15, 0);
            DateTime currDateTime2 = new DateTime(2021, 11, 23, 1, 25, 0);
            DateTime currDateTime3 = new DateTime(2021, 11, 23, 1, 35, 0);
            DateTime currDateTime4 = new DateTime(2021, 11, 23, 1, 45, 0);

            Dictionary<DateTime, int> currUserCountVsTimeStamp = new Dictionary<DateTime, int>();
            currUserCountVsTimeStamp[currDateTime1] = 10;
            currUserCountVsTimeStamp[currDateTime2] = 20;
            currUserCountVsTimeStamp[currDateTime3] = 30;
            currUserCountVsTimeStamp[currDateTime4] = 40;


            //calling the function to update these participants count according to the time stamp 
            DashboardViewModelForTest.UpdateUserCountVsTimeStamp(currUserCountVsTimeStamp);
            


            Assert.Equal(10, DashboardViewModelForTest.UserCountList[0]);
            Assert.Equal(20, DashboardViewModelForTest.UserCountList[1]);
            Assert.Equal(30, DashboardViewModelForTest.UserCountList[2]);
            Assert.Equal(40, DashboardViewModelForTest.UserCountList[3]);

            Assert.Equal("01:15", DashboardViewModelForTest.TimeStampsList[0]);
            Assert.Equal("01:25", DashboardViewModelForTest.TimeStampsList[1]);
            Assert.Equal("01:35", DashboardViewModelForTest.TimeStampsList[2]);
            Assert.Equal("01:45", DashboardViewModelForTest.TimeStampsList[3]);


            //say everything went fine 
            return;
        
        }



        [Fact]
        /// <summary>
        ///testing the function of calculating the updateuseridvschatcount 
        /// </summary>
        public void UpdateUserIdVsChatCount_Test()
        {
            //new System.Windows.Application();
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }

            Dictionary<int, int> currUserIdVsChatCount = new Dictionary<int, int>();
            currUserIdVsChatCount[1] = 10;
            currUserIdVsChatCount[2] = 20;
            currUserIdVsChatCount[4] = 30;

            //calling the function to update the values 
            DashboardViewModelForTest.UpdateUserIdVsChatCount(currUserIdVsChatCount);


            //now asserting the values for this purpose 
            Assert.Equal("1", DashboardViewModelForTest.UserIdList[0]);
            Assert.Equal("2", DashboardViewModelForTest.UserIdList[1]);
            Assert.Equal("4", DashboardViewModelForTest.UserIdList[2]);

            Assert.Equal(10, DashboardViewModelForTest.ChatCountListForUserId[0]);
            Assert.Equal(20, DashboardViewModelForTest.ChatCountListForUserId[1]);
            Assert.Equal(30, DashboardViewModelForTest.ChatCountListForUserId[2]);


            //say everything went fine 
            return;
        
        }



        [Fact]
        /// <summary>
        /// testing function to test the calculation of the attentive and non attentive users  
        /// </summary>
        public void CalculatePercentageOfAttentiveAndNonAttentiveUsers_Test()
        {
            int currNonAttentiveUsers = 50;
            int currAttentiveUsers = 50;
            DashboardViewModelForTest.TotalParticipantsCountSetter = 100;

            //calling the function
           DashboardViewModelForTest.CalculatePercentageOfAttentiveAndNonAttentiveUsers(currAttentiveUsers, currNonAttentiveUsers);

            //asserting the values 
            Assert.Equal(50, DashboardViewModelForTest.NonAttentiveUsersSetter);
            Assert.Equal(50, DashboardViewModelForTest.AttentiveUsersSetter);
            //say everything went fine 
            return;
        }



        [Fact]
        /// <summary>
        /// testing function to test the onclientsessioncganed function  
        /// </summary>
        public void OnClientSessionChanged_Test()
        {
            //new System.Windows.Application();
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }
            UserData user1 = new UserData("Rupesh kumar", 1);
            UserData user2 = new UserData("Saurabh Kumar", 2);
            UserData user3 = new UserData("Hrishi Raaj", 3);

            SessionData sessionData = new SessionData();
            sessionData.AddUser(user1);
            sessionData.AddUser(user2);
            sessionData.AddUser(user3);

            sessionData.sessionMode = "ExamMode";
            sessionData.sessionId = 1;

            //calling the function 
            DashboardViewModelForTest.OnClientSessionChanged(sessionData, 1);
            //System.Windows.Application.Current.Shutdown();

            //now asserting the values for this purpose 
            Assert.Equal("ExamMode", DashboardViewModelForTest.SessionModeSetter);
            Assert.Equal(3, DashboardViewModelForTest.TotalParticipantsCountSetter);
            Assert.Equal("Switch To LabMode", DashboardViewModelForTest.ButtonContentSetter);

            //say everything went fine 
            return;
        }




        [Fact]
        /// <summary>
        /// testing for function onanalytics changed  
        /// </summary>
        public void OnAnalyticsChanged_Test()
        {
            //new System.Windows.Application();
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }
            Dictionary<int, int> currUserIdVsChatCount = new Dictionary<int, int>();
            currUserIdVsChatCount[1] = 10;
            currUserIdVsChatCount[2] = 20;
            currUserIdVsChatCount[4] = 30;
            List<int> array  = new List<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);


            DateTime currDateTime1 = new DateTime(2021, 11, 23, 1, 15, 0);
            DateTime currDateTime2 = new DateTime(2021, 11, 23, 1, 25, 0);
            DateTime currDateTime3 = new DateTime(2021, 11, 23, 1, 35, 0);

            Dictionary<DateTime, int> currUserCountVsTimeStamp = new Dictionary<DateTime, int>();
            currUserCountVsTimeStamp[currDateTime1] = 10;
            currUserCountVsTimeStamp[currDateTime2] = 20;
            currUserCountVsTimeStamp[currDateTime3] = 30;

            Dictionary<string, int> userNameVsChatCount = new Dictionary<string, int>();
            userNameVsChatCount["Rupesh Kumar"] = 10;
            userNameVsChatCount["Hrishi Raaj"] = 20;

            SessionAnalytics sessionAnalytics = new SessionAnalytics();
            sessionAnalytics.chatCountForEachUser = currUserIdVsChatCount;
            sessionAnalytics.listOfInSincereMembers = array;
            sessionAnalytics.userCountVsTimeStamp = currUserCountVsTimeStamp;
            sessionAnalytics.userNameVsChatCount = userNameVsChatCount;

            SessionSummary sessionSummary = new SessionSummary();
            sessionSummary.userCount = 10;
            sessionSummary.chatCount = 20;
            sessionSummary.score = 200;

            //setting the summary inside the sessionAnalytics 
            sessionAnalytics.sessionSummary = sessionSummary;

            //now the analytics is set we have to call the function onanalytics changed 
            DashboardViewModelForTest.OnAnalyticsChanged(sessionAnalytics);

           

            //asserting the result values
            Assert.Equal(10, DashboardViewModelForTest.UserCountList[0]);
            Assert.Equal(20, DashboardViewModelForTest.UserCountList[1]);
            Assert.Equal(30, DashboardViewModelForTest.UserCountList[2]);


            Assert.Equal(10, DashboardViewModelForTest.ChatCountListForUserId[0]);
            Assert.Equal(20, DashboardViewModelForTest.ChatCountListForUserId[1]);
            Assert.Equal(30, DashboardViewModelForTest.ChatCountListForUserId[2]);

            Assert.Equal(200, DashboardViewModelForTest.SessionScoreSetter);
            Assert.Equal("Rupesh Kumar", DashboardViewModelForTest.UserNameList[0]);
            Assert.Equal("Hrishi Raaj", DashboardViewModelForTest.UserNameList[1]);
            Assert.Equal(10, DashboardViewModelForTest.ChatCountListForUserName[0]);
            Assert.Equal(20, DashboardViewModelForTest.ChatCountListForUserName[1]);

            //say everything went fine 
            return;
        }



        [Fact]
        /// <summary>
        /// function to test the calculation of engagement rate  
        /// </summary>
        public void CalculateEngagementRate_Test()
        {
            Dictionary<string, int> userNameVsChatCount = new Dictionary<string, int>();
            userNameVsChatCount["Rupesh Kumar"] = 10;
            userNameVsChatCount["Hrishi RAaaj"] = 10;

            DashboardViewModelForTest.TotalParticipantsCountSetter = 10;
            DashboardViewModelForTest.MaxTotalParticipantsCountSetter = 20;


            //calling the function 
            DashboardViewModelForTest.CalculateEngagementRate(userNameVsChatCount);

            //asserting the values 
            Assert.Equal("10%", DashboardViewModelForTest.EngagementRateSetter);


            //say everything went fine 
            return;
        }
    }
}
