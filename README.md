# Sample ASP.NET Core Application

Sample cross-platform ASP.NET Core application using [Docker](http://docker.com) and [MongoDB](http://mongodb.com).

## Prereqs

Before running the app you will need to install [Docker](https://www.docker.com/products/overview) and [Bower](https://bower.io/#install-bower).
Bower is a web package manager and Docker is used for running the app and MongoDB in containers.
Before installing Bower be sure you have installed [Node.js](https://nodejs.org/en/) which includes Node Package Manager (`npm`) that is used to install Bower.

## Run the app

* From the root of the checkout run:
  * `bower install`
  * `docker-compose build`
  * `docker-compose up`
* Navigate to the site on http://localhost
