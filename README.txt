
USING NUNIT V3 FOR THE UNIT TESTS

SOME IMPROVEMENTS I WOULD DO IF I HAD MORE TIME / IF IT WAS REAL PRODUCTION PROJECT

- I would have clarify the requirements better to understand what activate a membership entitles and what is a shipping slip, etc (now i just made assumptions), 
and spend bit more time understanding what kind of rules can there be if we can design something that make it even easier to import and execute rules
- I would have implemented a better way to Load the rules maybe through database or configuration file.
- Would have implemented proper dependency injector like Ninject or Castle Windsor.
- Would have using mock to mock some services and repos for the tests.
- Would have implemented more validations and checks around the Models like avoid creating a purchase order without items, a customer without basic details, etc. Also protected them more so certain fields can be modified in certain scenarios, etc
- Would have created a more distributed system instead of monolythic app, for example using events. You could raise events like payment made, or purchase order complete, which are received by other systems/services like
a membership service that would activate the membership, or a shipping service that will activate the shipping process, etc.