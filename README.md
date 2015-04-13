Asgard Web Portfolio Website
================

This is Still a Work in Progress, and the code is not building yet.

A website prototype built as an exmpale applications of best practices and patterns in web application development.

The website will have the following aspects to it:

* Blogging Engine
* Wishlist Manager
* Management Interface

Utilizing the following technologies:

* Azure Web Sites
* Azure Web Jobs
* Azure Storage
* Azure Active Directory
* Azure CDN - for client side libraries
* Aurelia Client Side Framework - [http://aurelia.io/](http://aurelia.io/)
* TypeScript
* Markdown

The Blogging Engine will save .md files onto blob storage and use an Azure Search index to look up tags / categories and another Azure Search index to look up full text.

The Wishlist Manager will have a pluggable architecture for different wishlist sites. It will use WebJobs to pull data from those APIs and save it into Table Storage.

The management interface will be logged in via Azure Active Directory (Single Sign On)
