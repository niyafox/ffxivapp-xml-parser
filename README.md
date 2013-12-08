ffxivapp-xml-parser
===================

Parser for the XML Log files that [FFXIV-APP](http://ffxiv-app.com/) creates.

There are a variety of parsers available for FFXIV: ARR, but they are, to the best of my knowledge, focused on parsing the battle logs.  That is, with a focus on combat, with particularly focus on DPS, healing, damage taken, etc...

This application is focused on the social side of the logs, and is designed to parse out the chat in say, emotes, linkshell, free company, and party chat, in order to produce an IRC-like log format that people can share with one another, or just look back at some of the conversations that they've had while exploring Eorzea.

Technical Junk
--------------
I've written this program in C# using Visual Studios Express 2010.  I'm more of a Java developer than C#, and so I'm sure I've not done the best things with the code.

Please forgive my mistakes, or if you know a better way to do something, please submit a pull request and I'll check it out and, probably, add it to the project.

This is a tool I'm developing for the community, which is why I'm sharing it, source code and all, with everyone.

I would like to add support for the raw log files that FFXIV:ARR creates itself at some point.  I've spent a fair bit of time trying to understand them, and while I understand most of the data, there's one particular piece of metadata that I'm missing, and that makes the process of parsing them much more difficult.

... I don't know how to tell the _type_ of message it is.  That is, the difference between party chat, say, emotes, etc...  Obviously a key part of a parser that pulls out messages to allow filtering by those types.
