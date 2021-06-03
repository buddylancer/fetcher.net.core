set names 'utf8';

delete from sources;
/* DO NOT change IDs after initial load */
insert into sources values (10, 'education.usnews.com', 1, 1,	'http://www.usnews.com/education',	'http://www.ff.com:8000/testing/feed?source=Education');
insert into sources values (20, 'health.usnews.com', 1, 1,	'http://health.usnews.com',		'http://www.ff.com:8000/testing/feed?source=Health');
insert into sources values (30, 'money.usnews.com', 1, 1,	'http://money.usnews.com',		'http://www.ff.com:8000/testing/feed?source=Money');
insert into sources values (40, 'news.usnews.com', 1, 1,	'http://www.usnews.com/news',		'http://www.ff.com:8000/testing/feed?source=News');
insert into sources values (50, 'opinion.usnews.com', 1, 1,	'http://www.usnews.com/opinion',	'http://www.ff.com:8000/testing/feed?source=Opinion');
insert into sources values (60, 'travel.usnews.com', 1, 1,	'http://travel.usnews.com',		'http://www.ff.com:8000/testing/feed?source=Travel');

delete from categories;
/*insert into categories values ('US', 'United States', ' US.| US;| US,|U.S.|USA|U.S.A.|United States', 0);*/
insert into categories values ('AL', 'Alabama', ' AL.| AL;| AL,|Alabama', 0);
insert into categories values ('AK', 'Alaska', ' AK.| AK;| AK,|Alaska', 0);
insert into categories values ('AZ', 'Arizona', ' AZ.| AZ;| AZ,|Arizona|Phoenix', 0);
insert into categories values ('AR', 'Arkansas', ' AR.| AR;| AR,|Arkansas', 0);
insert into categories values ('CA', 'California', ' CA.| CA;| CA,|California|Santa Barbara|San Francisco|Los Angeles|Los Ángeles', 0);
insert into categories values ('CO', 'Colorado', ' CO.| CO;| CO,|Colorado|Denver', 0);
insert into categories values ('CT', 'Connecticut', ' CT.| CT;| CT,|Connecticut', 0);
insert into categories values ('DE', 'Delaware', ' DE.| DE;| DE,|Delaware', 0);
insert into categories values ('FL', 'Florida', ' FL.| FL;| FL,|Florida|Miami', 0);
insert into categories values ('GA', 'Georgia', ' GA.| GA;| GA,|Georgia|Atlanta', 0);
insert into categories values ('HI', 'Hawaii', ' HI.| HI;| HI,|Hawaii|Honolulu', 0);
insert into categories values ('ID', 'Idaho', ' ID.| ID;| ID,|Idaho', 0);
insert into categories values ('IL', 'Illinois', ' IL.| IL;| IL,|Illinois|Chicago', 0);
insert into categories values ('IN', 'Indiana', ' IN.| IN;| IN,|Indiana|Indianapolis~IN...', 0);
insert into categories values ('IA', 'Iowa', ' IA.| IA;| IA,|Iowa|Des Moines', 0);
insert into categories values ('KS', 'Kansas', ' KS.| KS;| KS,|Kansas|Topeka~Arkansas', 0);
insert into categories values ('KY', 'Kentucky', ' KY.| KY;| KY,|Kentucky|Frankfort', 0);
insert into categories values ('LA', 'Louisiana', ' LA.| LA;| LA,|Louisiana|New Orlean|Nueva Orleans|Baton Rouge', 0);
insert into categories values ('ME', 'Maine', ' ME.| ME;| ME,|Maine|Augusta', 0);
insert into categories values ('MD', 'Maryland', ' MD.| MD;| MD,|Maryland|Annapolis', 0);
insert into categories values ('MA', 'Massachusetts', ' MA.| MA;| MA,|Massachusetts|Boston', 0);
insert into categories values ('MI', 'Michigan', ' MI.| MI;| MI,|Michigan|Lansing', 0);
insert into categories values ('MN', 'Minnesota', ' MN.| MN;| MN,|Minnesota|Saint Paul', 0);
insert into categories values ('MS', 'Mississippi', ' MS.| MS;| MS,|Mississippi|Jackson City', 0);
insert into categories values ('MO', 'Missouri', ' MO.| MO;| MO,|Missouri|Jefferson City', 0);
insert into categories values ('MT', 'Montana', ' MT.| MT;| MT,|Montana|Helena City', 0);
insert into categories values ('NE', 'Nebraska', ' NE.| NE;| NE,|Nebraska|Lincoln City', 0);
insert into categories values ('NV', 'Nevada', ' NV.| NV;| NV,|Nevada|Carson City', 0);
insert into categories values ('NH', 'New Hampshire', ' NH.| NH;| NH,|New Hampshire|Concord', 0);
insert into categories values ('NJ', 'New Jersey', ' NJ.| NJ;| NJ,|New Jersey|Trenton', 0);
insert into categories values ('NM', 'New Mexico', ' NM.| NM;| NM,|New Mexico|Santa Fe', 0);
insert into categories values ('NY', 'New York', ' NY.| NY;| NY,|New York|Albany', 0);
insert into categories values ('NC', 'North Carolina', ' NC.| NC;| NC,|North Carolina|Raleigh', 0);
insert into categories values ('ND', 'North Dakota', ' ND.| ND;| ND,|North Dakota|Bismarck', 0);
insert into categories values ('OH', 'Ohio', ' OH.| OH;| OH,|Ohio|Columbus', 0);
insert into categories values ('OK', 'Oklahoma', ' OK.| OK;| OK,|Oklahoma', 0);
insert into categories values ('OR', 'Oregon', ' OR.| OR;| OR,|Oregon|Salem~Jerusalem|Winston-Salem|Massachusetts', 0);
insert into categories values ('PA', 'Pennsylvania', ' PA.| PA;| PA,|Pennsylvania|Harrisburg', 0);
insert into categories values ('RI', 'Rhode Island', ' RI.| RI;| RI,|Rhode Island|Providence', 0);
insert into categories values ('SC', 'South Carolina', ' SC.| SC;| SC,|South Carolina|Columbia', 0);
insert into categories values ('SD', 'South Dakota', ' SD.| SD;| SD,|South Dakota|Pierre', 0);
insert into categories values ('TN', 'Tennessee', ' TN.| TN;| TN,|Tennessee|Nashville', 0);
insert into categories values ('TX', 'Texas', ' TX.| TX;| TX,|Texas|Austin', 0);
insert into categories values ('UT', 'Utah', ' UT.| UT;| UT,|Utah|Salt Lake City', 0);
insert into categories values ('VT', 'Vermont', ' VT.| VT;| VT,|Vermont|Montpelier', 0);
insert into categories values ('VA', 'Virginia', ' VA.| VA;| VA,|Virginia|Richmond', 0);
insert into categories values ('WA', 'Washington', ' WA.| WA;| WA,|Washington|Olympia', 0);
insert into categories values ('WV', 'West Virginia', ' WV.| WV;| WV,|West Virginia|Charleston', 0);
insert into categories values ('WI', 'Wisconsin', ' WI.| WI;| WI,|Wisconsin|Madison', 0);
insert into categories values ('WY', 'Wyoming', ' WY.| WY;| WY,|Wyoming|Cheyenne', 0);
/* --- */
insert into categories values ('AS', 'American Samoa', ' AS.| AS;| AS,|American Samoa|Pago Pago', 0);
insert into categories values ('DC', 'District of Columbia', ' DC.| DC;| DC,|District of Columbia', 0);
insert into categories values ('FM', 'Federated States of Micronesia', ' FM.| FM;| FM,|Federated States of Micronesia', 0);
insert into categories values ('GU', 'Guam', ' GU.| GU;| GU,|Guam|Hagåtña', 0);
insert into categories values ('MH', 'Marshall Islands', ' MH.| MH;| MH,|Marshall Islands', 0);
insert into categories values ('MP', 'Northern Mariana Islands', ' MP.| MP;| MP,|Northern Mariana Islands|Saipan', 0);
insert into categories values ('PW', 'Palau', ' PW.| PW;| PW,|Palau', 0);
insert into categories values ('PR', 'Puerto Rico', ' PR.| PR;| PR,|Puerto Rico|San Juan', 0);
insert into categories values ('VI', 'Virgin Islands', ' VI.| VI;| VI,|Virgin Islands|Charlotte Amalie', 0);
/* --- */
insert into categories values ('Britain', 'World - Britain', 'Britain|Britanian|British|London', 0);
insert into categories values ('Canada', 'World - Canada', 'Canada|Vancouver', 0);
insert into categories values ('China', 'World - China', 'China|Chinese', 0);
insert into categories values ('Czechia', 'World - Czech Republic', 'Czech Republic|Prague', 0);
insert into categories values ('France', 'World - France', 'France|French|Paris', 0);
insert into categories values ('Germany', 'World - Germany', 'Germany', 0);
insert into categories values ('Iran', 'World - Iran', 'Iran|Iranian', 0);
insert into categories values ('Mexico', 'World - Mexico', 'Mexico', 0);
insert into categories values ('Netherlands', 'World - Netherlands', 'Netherlands|Amsterdam', 0);
insert into categories values ('Poland', 'World - Poland', 'Poland|Polish|Warshawa', 0);
insert into categories values ('Russia', 'World - Russia', 'Russia|Moscow', 0);
insert into categories values ('South Korea', 'World - South Korea', 'South Korea', 0);
insert into categories values ('Scotland', 'World - Scotland', 'Scotland', 0);
