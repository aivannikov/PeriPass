# PeriPass

<p>This is the impelemtation of finding the word combinations according to the maximum final word length condition.</p>
<p>The goal is to process the word parts of different length and to output all the variants they 
could form a longer word of the required length.</p>
<p>This soution outputs the variant only if 2 word parts can be a word of the required length.</p>
<p>The list of word parts is retrieved from the source(text file, database etc).</p>

### Solution Description

Solution contains 3 folders:

<ol>
  <li>WordsCreator.ConsoleApp - contains console application which shows the user all the word variants.</li>
  <li>WordsCreator.Core - is a business layer where the basic algorithm implementation is located.</li>
  <li>WordsCreator.UnitTests - contains some unit tests.</li>
</ol>




### Starting Application

For starting the application you should open the Terminal 
and go to the solution folder.
Use .Net Core CLI 

<ol>
  <li><code>cd WordsCreator.ConsoleApp</code>
  <li><code>dotnet run</code></li>
</ol>

For running Unit tests go to the solution folder and type <code>dotnet test</code>.

