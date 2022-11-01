# Skilltest-Appex

* Lag en webapplikasjon som lar deg lagre potensielle kunder basert på oppslag/data om bedrifter fra Brønnøysundregisteret. Brukeren må kunne registrere/lagre ekstra informasjon om hver bedrift, f.eks. et notat.
* Hent inn/vis data fra ett eller flere andre API’er basert på org.nr./postnr. koblet til bedriften. Forskjellige åpne API’er kan du finne her: https://data.norge.no/.
* Teknologi velger du selv, men sett opp en readme-fil som viser hvordan løsningen startes (eller legg den ut på en hostingtjeneste et sted).
* Gi oss tilgang til et Git-repository med koden (eller la det ligge public). 

Du setter ambisjonsnivået selv, og som du ser er oppgaven veldig åpen. Hvordan du løser frontend og backend er opp til deg, og hvordan du velger å gå frem på for å løse oppgaven er også opp til deg (planlegging i forkant/skissing/løse den «as you go»). Vi går gjennom resultatet når du føler deg ferdig med oppgaven. Etter at vi har gjennomgått resultatet internt tar vi en gjennomgang sammen med deg, der du kan presentere og forklare mer hva du har tenkt/hvordan du har løst oppgaven.

# Planlegging

Planen er å lage en simpel Single-page webapplikasjon der man kan legge-til/slette/endre bedrifter. Jeg la til ordet "simpel" fordi denne applikasjonen kommer til ha minimalt med funksjoner. Det vil si ingen brukere, autorisering osv, men gjøre den skalerbar slik at det er mulighet til å legge til ekstra funksjonaliteter.

Denne siden viser detaljert all informasjon om bedriften basert på data fra Brønnøysundregistreret. I tillegg er det en notatblokk der man kan skrive ekstra informasjon som er relevant.
![Screenshot_20221101_124504](https://user-images.githubusercontent.com/42601584/199226385-aa17fa33-64b5-47fd-8338-0ee3415456e2.png)

Liste av alle innlagte bedrifter. Du har også muligheten til å søke etter dem med orginasasjonsnummer. Skilles om de er potensiell kunde og nåværende kunde. Hver "Card" har en notat knapp. Av å klikke på den får man opp natatblokken som man har skrevet om den spesifikke bedriften.
![Screenshot_20221101_124523](https://user-images.githubusercontent.com/42601584/199226408-b00f1b18-148d-4082-844d-665b95795090.png)

Udetaljert "Legg til kunde" side. Brukes til å legge til en bedrift. Her vil det være punkter man må notere i og noen man kan ignorerer.
![Screenshot_20221101_124547](https://user-images.githubusercontent.com/42601584/199226420-1b30bfeb-503b-47c0-9f11-66376fc90423.png)
