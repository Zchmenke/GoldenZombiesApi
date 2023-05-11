# GoldenZombiesApi
Group Project for API:S

Vi valde att göra vår databas okomplicerad med bara tre tables, vi anser inte att uppgiften kräver mer än det.
Genom att koppla employee och project till timereport som en kopplingstabell så får vi tillgång till all funktionalitet som uppgiften efterfrågar. 
Med vår struktur så kan join syntaxen bli lite längre än om vi hade haft en many-to-many relation mellan project och employee, dock så blir det väldigt enkelt för oss
att lägga till nya timereports med denna struktur. 

Vi valde att göra ett interface för varje repository istället för att göra ett generiskt interface för allihop. 
Detta gjorde vi för att göra en mer översiktlig struktur och öka läsbarheten i koden, vi ville inte heller ha en massa icke implementerade metoder i våra repositorys.
Nackdelen med vårt val är att det blir mer kod att skriva vilket tar längre tid.

Vi har försökt hålla alla metoder och kod så konsekvent som möjligt för att man enklare ska kunna förstå koden.
Vi använde oss av data annotations/validation för att försäkra oss om att datan som kommer in blir korrekt.
