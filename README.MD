### Kipon Dynamics 365 Web resources

Ths project is a basic visual studio project for developing and creating typescript based web resources for running
as part of Dynamics 365 forms etc.

If you need to add functionality to an existing Dynamiccs 365 form, you typically uses javascript to interact with the form elements.

This project is offering an alternative approach, using typescript. The advantage of typescript for this type of development is mainly
intelicense in you developer tool, and some level of compiler check of your code.

## Project offer
* A typescript definition generator, that generates typescript definition files ( *.d.ts) files that match your forms. This will allow you to work with stronly typed objects, and
  any change to your form will reflect in your code, allowing you to quickly find consequences in your code as a result of form changes. This tool is for
  your forms, the same as svcutil is for your entities when writing C# code using the Dynamics 365 SDK.
* Typescript tools
   * kipon-xrmservice. This is a port of my angular web-api service that allow your script to interact with Dynamics 365 through the WebAPI. Kipon-xrmservice has originally
   been build for angular, however this version is 100% indenpendend, and allow you to interact with Dynamics 365 WebAPI using the same methods.
   It works exactly the same way. The version included in this project DOES NOT REQURE ANGULAR.
   * DefinitelyTyped. This project includes the powerfull definitions from defenetly typed. This allow you to work with the full Dynamics 365 UI SDK, using strongly typed typescript.
   * This tool contains an initial polyfill.js fill you can extend according the your needs, based on your required level of browser support.
* Deployment tool. Finally this tool contains a C# tool that can deploy your web resource into your Dynamics 365 solution. Instead of uploading files individually on change,
  this command line tool can detect files that has been changed, and upload these files to Dynamics 365. It will also publish script changes. Finally this tool is able to
  merge several scripts into one single script that will be deployed to Dynamics 365. So instead of haviing to add several scripts to a form, they can be merged at deployment time, 
  so you only need to add a single script file to your form.


## Getting started
To get started, simply fork or download this project, and include the solution items to your own Dynamics 365 development project.
You should include the following two folders

* Kipon.WebResources.Tools
* WebResources

### WebResources


WORK IN PROGRESS... last updated 2018-25-11

License MIT.

(c) Kipon ApS, 2018