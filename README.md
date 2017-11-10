Project description
---
Create a web app for an issue tracking system. An issue consists of the following basic properties:

1. Title
2. Status
3. Description
4. Severity
5. Assignee
6. DueDate

A user can create a new issue and view it afterwards.

All issues should be persisted somewhere for retrieval.

An issue can be retrieved via a unique URL (e.g. http://www.myissues.com/issue/12345)

Feel free to spend more time on your areas of strengths (UI, Data Model or Server-Side Architecture)

Documentations
---
Update this Readme.md describing how to compile and run the project.

The project should not have any dependencies on non-open source software.

It should be easy to setup and run on a Windows machine

Submission instructions
---
Clone this repository

Complete the project as described above in your own local respository

Create a git bundle: `git bundle create your-name.bundle --all`

Email the bundle file to the person who contacted you

Evaluations
---
Did you follow instructions?

Did you document the instructions to compile and run in this Readme.md?

Did you separate the concerns in your application?

Did you document any areas of improvement that you considered but did not have time to implement?

Did you comment your code appropriately?



--

Install Steps
---

+ Run Rest Service:
  -  Open Orbit.sln from Visual Studio 2015
  -  Set "Orbit.Web.Api" project at the start project
  -  Run this project in Debug mode which will start the app at: http://localhost:55912/ 


+ Install Node.js from  https://nodejs.org/dist/v6.9.5/node-v6.9.5-x64.msi
+ Install Angular/cli:  
   ***c:\>npm install -g @angular/cli@latest***
+ Build Orbit.Web:  
   ***c:\orbit\orbit\Orbit\Orbit.Web>npm install***
+ Start Orbit.Web     
   ***c:\orbit\orbit\Orbit\Orbit.Web>ng serve***
+ Access the Orbit.Web from Chrome browser, default parot is 4200: (IE low version is not fully test.)
 ***http://localhost:4200***

TODO List:
---
* Authentication
* Log with Log4Net
* More test cases
