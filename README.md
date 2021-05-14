# ColorLogger
This is a simple wrapper for WriteLine that adds colors and prefixes to the output text.\
You can take either the dll or the nuget package to connect to your solution.

# Usage:\
simply display messages with the [info] prefix\
`Log("text");`\
Output: `[INFO] text`.

Output with your level:\
`Log(LogLevel.Debug, "text");`\
Output: `[DEBUG] text`.

Output without prefix:\
`Log(LogLevel.Warning, "text", false);`\
Output: `text`(output is colored anyway).

Output with a long prefix:\
`Log(LogLevel.Critical, "text", true, false);`\
Output: `[CRITICAL] text`.

LogLevel description
##### `Debug`
Foreground color - Gray
Background color - Black
Short name - Debug

##### `Information`
Foreground color - White
Background color - Black
Short name - Info

##### `Warning`
Foreground color - Yellow
Background color - Black
Short name - Warn

##### `Error`
Foreground color - Red
Background color - Black
Short name - Err

##### `Critical`
Foreground color - Red
Background color - White
Short name - Crit
