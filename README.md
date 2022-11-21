# Translation Office

Translation office management system. 

Translation Office is a software project being developed for helping translator office's in customer relations and their everyday tasks. The project consists of two parts:

1. First one is for helping customers to purchase a custom translation job without much hassle through the office's website. 
1. Second part is the management of the office jobs ie. the translation tasks after purchase, assigning adding removing translators, analysis of translation fees based on time, translator etc.

These two different business parts of software are web based applications, one for customers/clients the other for office staff.

## Requirements

1. Customer Purchasing Translation Task
    a. Customer visits the office website.
    a. If they are already a client, they log in.
    a. They choose their translation languages to and from.
    a. They upload their scanned document to be analysed
    a. They choose what kind of translation they need (Medical, Technical, Law etc.)
    a. They choose speed of translation task.
    a. They choose if they need approval from notary.
    a. They see the fee of translation task, any reward coupons and discounts will be applied if they are a client. The fee will be based on firstly the scanned document (word count), the languages, notary fee calculation and other factors customer chose.
    a. The customer choose payment method, credit card, etc.
    a. For payment methods which don't automatically transfer money from customer's account, the customer receives a message with a link to assure they have paid translation fee. 


## Tech Stack

* .Net 7.0
* Docker
* GraphQL
* DDD

## Architecture

Application has a monolithitic architecture, with ability to split to microservices afterwards.
All bounded contexts follow hexagonal architecture with DDD.

## Dev-Ops

Go to src folder and run following commands:

### Build Api Image

```
docker build -t ghcr.io/subanov/translation-office/api .
```

### Run full infrastructure

```
docker compose up -d
```
