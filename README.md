# Skilltest-Appex

* Lag en webapplikasjon som lar deg lagre potensielle kunder basert på oppslag/data om bedrifter fra Brønnøysundregisteret. Brukeren må kunne registrere/lagre ekstra informasjon om hver bedrift, f.eks. et notat.
* Hent inn/vis data fra ett eller flere andre API’er basert på org.nr./postnr. koblet til bedriften. Forskjellige åpne API’er kan du finne her: https://data.norge.no/.
* Teknologi velger du selv, men sett opp en readme-fil som viser hvordan løsningen startes (eller legg den ut på en hostingtjeneste et sted).
* Gi oss tilgang til et Git-repository med koden (eller la det ligge public). 

Du setter ambisjonsnivået selv, og som du ser er oppgaven veldig åpen. Hvordan du løser frontend og backend er opp til deg, og hvordan du velger å gå frem på for å løse oppgaven er også opp til deg (planlegging i forkant/skissing/løse den «as you go»). Vi går gjennom resultatet når du føler deg ferdig med oppgaven. Etter at vi har gjennomgått resultatet internt tar vi en gjennomgang sammen med deg, der du kan presentere og forklare mer hva du har tenkt/hvordan du har løst oppgaven.

## Planlegging

Planen er å lage en simpel Single-page webapplikasjon der man kan legge-til/slette/endre bedrifter. Jeg la til ordet "simpel" fordi denne applikasjonen kommer til ha minimalt med funksjoner. Det vil si ingen brukere, autorisering osv, men gjøre den skalerbar slik at det er mulighet til å legge til ekstra funksjonaliteter.

Denne siden viser detaljert all informasjon om bedriften basert på data fra Brønnøysundregistreret. I tillegg er det en notatblokk der man kan skrive ekstra informasjon som er relevant.
![Screenshot_20221101_124504](https://user-images.githubusercontent.com/42601584/199226385-aa17fa33-64b5-47fd-8338-0ee3415456e2.png)

Liste av alle innlagte bedrifter. Du har også muligheten til å søke etter dem med orginasasjonsnummer. Skilles om de er potensiell kunde og nåværende kunde. Hver "Card" har en notat knapp. Av å klikke på den får man opp natatblokken som man har skrevet om den spesifikke bedriften.
![Screenshot_20221101_124523](https://user-images.githubusercontent.com/42601584/199226408-b00f1b18-148d-4082-844d-665b95795090.png)

Udetaljert "Legg til kunde" side. Brukes til å legge til en bedrift. Her vil det være obligatoriske felt og valgfritt felt.
![Screenshot_20221101_124547](https://user-images.githubusercontent.com/42601584/199226420-1b30bfeb-503b-47c0-9f11-66376fc90423.png)

Domain model
![Screenshot_20221101_012842](https://user-images.githubusercontent.com/42601584/199232415-b1fa34f2-957d-4835-ae9f-9c32af14a4f0.png)

## Utførelse

Endret mening om å gjøre det så simpel så mulig. Oppdaterte domene modellen og la til en "AppUser" klasse. Dette skulle bli en web applikasjon med autentisering der hver bruker kunne lagre en list av bedrifter. Dessverre fikk jeg ikke til API kall og endte med 'error 404 not found' på hver av API kallene tross for at databasen var koblet til backend. Letet lenge, men fant aldri ut hva som manglet eller om jeg bare skrev API kallet feil.

Teknologien jeg brukte var .Net 6 core som backend, vue3 js som frontend og MySql som database.

Tankegangen min var å lage en webapplikasjon der man måtte registrere en bruker for å bruke resten av funksjonalitetene. Funksjonalitetene er 'Add a company' som legger til en bruker til listen av bedrifter. Denne metoden tar i mot organisasjonsnummeret og navnet til bedriften, og i tillegg kan man legge til notater. Bedriften blir lagt inn i listen med alle andre bedrifter du har lag til og er listet ut som KORT. Funksjonaliteter der var blant annet søking av bedrift, og trykke på en av kortene der man fikk opp full oversikt av bedriften og kan redigere på notaten. De to siste nevnte ble ikke implementert pga prioritering av backend. 

For å oppsumere arbeidet er jeg bitter av å ikke få til API kallene og bruken av tiden min til å koble sammen backend, frontend og database. Brukte 10 dager på å koble sammen alt, som jeg burde gjort på en enkel dag om jeg hadde brukt tiden effektiv. Dette ville ført mer tid til å løse problemet med API kall. Derimot var det kjekt å bruke en ny rammeverk og holde på med SQL. Sist gang jeg holdt på med .Net var i versjon 5. Overgangen fra versjon 5 til 6 var stor, men gjorde det mye enklere å koble sammen backend og frontend. Det var de siste 2 ukene jeg jobbet mest det denne oppgaven, som passet dårlig pga 2 sykdom etter hverandre de siste 10 dagene.

### Domain model
![Screenshot_20221130_115414](https://user-images.githubusercontent.com/42601584/204925917-24f7465b-7d4a-4cd7-ad4f-e9a8a864f8a5.png)

### Company list med dummy data
![Screenshot_20221201_121400](https://user-images.githubusercontent.com/42601584/204928205-dbcea555-9e6c-4c6b-a260-53d977a68256.png)



