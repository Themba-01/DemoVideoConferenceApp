DemoVideoConferenceApp/
├── .gitignore
├── DemoVideoConference.sln
├── DemoVideoConference.Client/
│   ├── App.razor
│   ├── DemoVideoConference.Client.csproj
│   ├── _Imports.razor
│   ├── Program.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Extensions/
│   │   └── IHttpExtension.cs
│   ├── Layout/
│   │   ├── AdminLandingLayout.razor
│   │   ├── AttendeeLayout.razor
│   │   ├── DashboardLayout.razor
│   │   ├── MainLayout.razor
│   │   ├── MainLayout.razor.css
│   │   ├── NavMenu.razor
│   │   ├── NavMenu.razor.css
│   ├── Pages/
│   │   ├── Counter.razor
│   │   ├── FooterComponent.razor
│   │   ├── Home.razor
│   │   ├── Weather.razor
│   │   ├── Admin/
│   │   │   ├── Authentication/
│   │   │   │   ├── LandingPage.razor
│   │   │   │   ├── LogoutPage.razor
│   │   │   │   ├── RegisterPage.razor
│   │   │   ├── Dashboard/
│   │   │   │   ├── AppbarComponent.razor
│   │   │   │   ├── DashboardPage.razor
│   │   │   │   ├── MeetingPage.razor
│   │   │   ├── HeaderComponent.razor
│   │   ├── User/
│   │   │   ├── JoinMeetingPage.razor
│   ├── Services/
│   │   ├── IAuthService.cs
│   │   ├── IChatService.cs          
│   │   ├── IMeetingService.cs
│   │   ├── ITwilioService.cs
│   ├── States/
│   │   ├── CustomAuthStateProvider.cs
│   │   ├── NavState.cs
│   ├── wwwroot/
│   │   ├── css/
│   │   │   ├── app.css
│   │   ├── favicon.png
│   │   ├── icon-192.png
│   │   ├── index.html
│   │   ├── js/
│   │   │   ├── twilio-video.js
│   │   ├── lib/
│   │   │   ├── bootstrap/
│   │   │   │   ├── dist/
│   │   │   │   │   ├── css/
│   │   │   │   │   │   ├── bootstrap-grid.css
│   │   │   │   │   │   ├── bootstrap-grid.css.map
│   │   │   │   │   │   ├── bootstrap-grid.min.css
│   │   │   │   │   │   ├── bootstrap-grid.min.css.map
│   │   │   │   │   │   ├── bootstrap-grid.rtl.css
│   │   │   │   │   │   ├── bootstrap-grid.rtl.css.map
│   │   │   │   │   │   ├── bootstrap-grid.rtl.min.css
│   │   │   │   │   │   ├── bootstrap-grid.rtl.min.css.map
│   │   │   │   │   │   ├── bootstrap-reboot.css
│   │   │   │   │   │   ├── bootstrap-reboot.css.map
│   │   │   │   │   │   ├── bootstrap-reboot.min.css
│   │   │   │   │   │   ├── bootstrap-reboot.min.css.map
│   │   │   │   │   │   ├── bootstrap-reboot.rtl.css
│   │   │   │   │   │   ├── bootstrap-reboot.rtl.css.map
│   │   │   │   │   │   ├── bootstrap-reboot.rtl.min.css
│   │   │   │   │   │   ├── bootstrap-reboot.rtl.min.css.map
│   │   │   │   │   │   ├── bootstrap-utilities.css
│   │   │   │   │   │   ├── bootstrap-utilities.css.map
│   │   │   │   │   │   ├── bootstrap-utilities.min.css
│   │   │   │   │   │   ├── bootstrap-utilities.min.css.map
│   │   │   │   │   │   ├── bootstrap-utilities.rtl.css
│   │   │   │   │   │   ├── bootstrap-utilities.rtl.css.map
│   │   │   │   │   │   ├── bootstrap-utilities.rtl.min.css
│   │   │   │   │   │   ├── bootstrap-utilities.rtl.min.css.map
│   │   │   │   │   │   ├── bootstrap.css
│   │   │   │   │   │   ├── bootstrap.css.map
│   │   │   │   │   │   ├── bootstrap.min.css
│   │   │   │   │   │   ├── bootstrap.min.css.map
│   │   │   │   │   │   ├── bootstrap.rtl.css
│   │   │   │   │   │   ├── bootstrap.rtl.css.map
│   │   │   │   │   │   ├── bootstrap.rtl.min.css
│   │   │   │   │   │   ├── bootstrap.rtl.min.css.map
│   │   │   │   │   ├── js/
│   │   │   │   │   │   ├── bootstrap.bundle.js
│   │   │   │   │   │   ├── bootstrap.bundle.js.map
│   │   │   │   │   │   ├── bootstrap.bundle.min.js
│   │   │   │   │   │   ├── bootstrap.bundle.min.js.map
│   │   │   │   │   │   ├── bootstrap.esm.js
│   │   │   │   │   │   ├── bootstrap.esm.js.map
│   │   │   │   │   │   ├── bootstrap.esm.min.js
│   │   │   │   │   │   ├── bootstrap.esm.min.js.map
│   │   │   │   │   │   ├── bootstrap.js
│   │   │   │   │   │   ├── bootstrap.js.map
│   │   │   │   │   │   ├── bootstrap.min.js
│   │   │   │   │   │   ├── bootstrap.min.js.map
│   │   ├── sample-data/
│   │   │   ├── weather.json
├── DemoVideoConference.Server/
│   ├── DemoVideoConference.Server.csproj
│   ├── DemoVideoConference.Server.http
│   ├── Program.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── VideoConference.db
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── MeetingController.cs
│   │   ├── TwilioController.cs
│   ├── Features/
│   │   ├── Authentication/
│   │   │   ├── CreateUserAccount/
│   │   │   │   ├── Command/
│   │   │   │   │   ├── CreateUserCommand.cs
│   │   │   │   ├── Handler/
│   │   │   │   │   ├── CreateUserHandler.cs
│   │   │   ├── LoginUser/
│   │   │   │   ├── Command/
│   │   │   │   │   ├── LoginUserCommand.cs
│   │   │   │   ├── Handler/
│   │   │   │   │   ├── LoginUserHandler.cs
│   │   ├── ChatFeature/
│   │   │   ├── Hubs/               
│   │   │   │   ├── ChatHub.cs
│   │   ├── MeetingFeature/
│   │   │   ├── CreateMeeting/
│   │   │   │   ├── Command/
│   │   │   │   │   ├── CreateMeetingCommand.cs
│   │   │   │   ├── Handler/
│   │   │   │   │   ├── CreateMeetingHandler.cs
│   │   │   ├── GetMeetings/
│   │   │   │   ├── GetMeetingQuery.cs
│   │   │   │   ├── Handler/
│   │   │   │   │   ├── GetMeetingsHandler.cs
│   │   │   ├── GetRecentMeetings/
│   │   │   │   ├── Query/
│   │   │   │   │   ├── GetRecentMeetingsQuery.cs
│   │   │   │   ├── Handler/
│   │   │   │   │   ├── GetRecentMeetingsHandler.cs
│   ├── Helpers/
│   │   ├── ITokenGenerator.cs
│   ├── Infrastructure/
│   │   ├── Data/
│   │   │   ├── AppDbContext.cs
│   │   ├── Services/
│   │   │   ├── ITwilioService.cs
│   ├── Migrations/
│   │   ├── 20250605225048_Initial.cs
│   │   ├── 20250605225048_Initial.Designer.cs
│   │   ├── 20250607203526_UpdateMeetingModel.cs
│   │   ├── 20250607203526_UpdateMeetingModel.Designer.cs
│   │   ├── AppDbContextModelSnapshot.cs
│   ├── Models/
│   │   ├── AppUser.cs
│   │   ├── Meeting.cs
├── DemoVideoConference.Shared/
│   ├── DemoVideoConference.Shared.csproj
│   ├── Authentication/
│   │   ├── Requests/
│   │   │   ├── CreateUserRequest.cs
│   │   │   ├── LoginUserRequest.cs
│   │   ├── Responses/
│   │   │   ├── CreateUserResponse.cs
│   │   │   ├── LoginResponse.cs
│   ├── Meeting/
│   │   ├── Requests/
│   │   │   ├── AttachDetailsToConnectionIdRequest.cs
│   │   │   ├── CreateMeetingRequest.cs
│   │   │   ├── GetMeetingRequest.cs
│   │   │   ├── GetRecentMeetingsRequests.cs
│   │   ├── Responses/
│   │   │   ├── AttachDetailsToConnectionIdResponse.cs
│   │   │   ├── ChatMessage.cs        // Added for chat feature
│   │   │   ├── CreateMeetingResponse.cs
│   │   │   ├── GetMeeting.cs
│   │   │   ├── GetMeetingsResponse.cs
│   │   │   ├── GetRecentMeetingsResponse.cs
│   │   │   ├── TwilioServiceResponse.cs
│   ├── ServiceResponse.cs
