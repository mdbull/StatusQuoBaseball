
# StatusProBaseball


## T:StatusQuoBaseball.Base.BatterTypes

Batter types.


### F:StatusQuoBaseball.Base.BatterTypes.Average

Represents an average batter.


### F:StatusQuoBaseball.Base.BatterTypes.Excellent

Represents an excellent batter.


### F:StatusQuoBaseball.Base.BatterTypes.Poor

Represents a poor batter.


### F:StatusQuoBaseball.Base.BatterTypes.Unknown

Represents an unknown batter type.


## T:StatusQuoBaseball.Base.BattingResults

Batting results.


### F:StatusQuoBaseball.Base.BattingResults.BB

Represents a BB.


### F:StatusQuoBaseball.Base.BattingResults.Double

Represents a double.


### F:StatusQuoBaseball.Base.BattingResults.FO

Represents a flyout.


### F:StatusQuoBaseball.Base.BattingResults.GO

Represents a groundout.


### F:StatusQuoBaseball.Base.BattingResults.HBP

Represents a HBP.


### F:StatusQuoBaseball.Base.BattingResults.HR

Represents a hr.


### F:StatusQuoBaseball.Base.BattingResults.K

Represents a K.


### F:StatusQuoBaseball.Base.BattingResults.Single

Represents a single.


### F:StatusQuoBaseball.Base.BattingResults.Triple

Represents a triple.


## T:StatusQuoBaseball.Base.BattingStatisticsContainer

Batting stats container.


### M:StatusQuoBaseball.Base.BattingStatisticsContainer.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Base.BattingStatisticsContainer.#ctor(player)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| player | *StatusQuoBaseball.Base.Player*<br>Player. |

### P:StatusQuoBaseball.Base.BattingStatisticsContainer.AtBats

Gets or sets at bats.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.BattingAverage

Gets the batting average.


### M:StatusQuoBaseball.Base.BattingStatisticsContainer.ClearStats

Clears the stats.


### M:StatusQuoBaseball.Base.BattingStatisticsContainer.Clone

Clone this instance.


#### Returns

object


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Doubles

Gets or sets the doubles.


### F:StatusQuoBaseball.Base.BattingStatisticsContainer.EmptyBattingStatisticsContainer

The empty batting statistics container.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.FlyOuts

Gets or sets the fly outs.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.GroundOuts

Gets or sets the ground outs.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.HitByPitches

Gets or sets the hit by pitches.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Hits

Gets or sets the hits.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Homeruns

Gets or sets the homeruns.


### M:StatusQuoBaseball.Base.BattingStatisticsContainer.LogStat(result, toIncrement)

Logs the stat.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |
| toIncrement | *System.Int32*<br>If set to 1 is run. |

### P:StatusQuoBaseball.Base.BattingStatisticsContainer.OnBasePercentage

Gets the on base percentage.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.PlateAppearances

Gets or sets the plate appearances.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.RBI

Gets or sets the runs batted in.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Runs

Gets or sets the runs.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.SacrificeFlyouts

Gets or sets the sacrifice flyouts.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Singles

Gets or sets the singles.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.SluggingPercentage

Gets the slugging percentage.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.StealAttempts

Gets or sets the steal attempts.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.StolenBases

Gets or sets the stolen bases.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Strikeouts

Gets or sets the strikeouts.


### M:StatusQuoBaseball.Base.BattingStatisticsContainer.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Triples

Gets or sets the triples.


### P:StatusQuoBaseball.Base.BattingStatisticsContainer.Walks

Gets or sets the walks.


## T:StatusQuoBaseball.Base.BattingStats

Batting stats.


### M:StatusQuoBaseball.Base.BattingStats.#ctor(controlModifier, playerSpeed, battingResultData)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controlModifier | *System.Int32*<br>int |
| playerSpeed | *System.Int32*<br>int |
| battingResultData | *System.Int32[]*<br>int |

### P:StatusQuoBaseball.Base.BattingStats.BatterRating

Gets or sets the batter rating.


### P:StatusQuoBaseball.Base.BattingStats.BattingResults

Gets the batting results.


### P:StatusQuoBaseball.Base.BattingStats.BattingResultsRanges

Gets the batting results ranges.


### P:StatusQuoBaseball.Base.BattingStats.BattingStatistics

Gets or sets the batting statistics for the year the player played in.


### M:StatusQuoBaseball.Base.BattingStats.BuildToString

Builds to string.


### M:StatusQuoBaseball.Base.BattingStats.CalculateBatterRating(games, battingAverage)

Calculates the batter rating of a player


#### Returns

int

| Name | Description |
| ---- | ----------- |
| games | *System.Int32*<br>int |
| battingAverage | *System.Double*<br>double |

### M:StatusQuoBaseball.Base.BattingStats.CalculateControlModifier(games, batterRating)

Calculates the control rating.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| games | *System.Int32*<br>int |
| batterRating | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.BattingStats.CalculatePowerRating(battingResultData)

Calculates the power rating.

| Name | Description |
| ---- | ----------- |
| battingResultData | *System.Int32[]*<br>int[] |

### M:StatusQuoBaseball.Base.BattingStats.CalculateSpeed(stolenBases, stealAttempts)

Calculates the speed of a player.


#### Returns

The speed.

| Name | Description |
| ---- | ----------- |
| stolenBases | *System.Int32*<br>Stolen bases. |
| stealAttempts | *System.Int32*<br>Steal attempts. |

### M:StatusQuoBaseball.Base.BattingStats.CalculateStamina(gamesPlayed)

Calculates the stamina.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| gamesPlayed | *System.Int32*<br>int |

### P:StatusQuoBaseball.Base.BattingStats.ControlModifier

Gets or sets the control.


### M:StatusQuoBaseball.Base.BattingStats.EachElementIsLess(array)

Eachs the element is less.


#### Returns

true, if element is less was eached, false otherwise.

| Name | Description |
| ---- | ----------- |
| array | *System.Int32[]*<br>int[] |

### M:StatusQuoBaseball.Base.BattingStats.FindFirstIndexOf(val, array)

Finds the first index of val.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| val | *System.Int32*<br>int |
| array | *System.Int32[]*<br>int[] |

### P:StatusQuoBaseball.Base.BattingStats.GamesPlayed

Gets or sets the games played.


### M:StatusQuoBaseball.Base.BattingStats.GenerateBattingStats(batterType)

Generates the batting stats.


#### Returns

BattingStats

| Name | Description |
| ---- | ----------- |
| batterType | *StatusQuoBaseball.Base.BatterTypes*<br>BatterTypes |

### M:StatusQuoBaseball.Base.BattingStats.IsHit(result)

Check if result is a hit.


#### Returns

true, if hit was ised, false otherwise.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Base.BattingResults*<br>bool |

### M:StatusQuoBaseball.Base.BattingStats.IsHit(result)

Checks if result is a hit.


#### Returns

true, if hit was ised, false otherwise.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Base.PitchResults*<br>bool |

### M:StatusQuoBaseball.Base.BattingStats.LoadBattingResultsRange(battingResultData)

Loads the batting results range.

| Name | Description |
| ---- | ----------- |
| battingResultData | *System.Int32[]*<br>BattingResults[] |

### M:StatusQuoBaseball.Base.BattingStats.LoadBattingStats(System.Collections.Generic.Dictionary{System.Int32,System.Collections.Generic.Dictionary{System.String,System.Object}})

Loads the batting stats.


#### Returns

BattingStats[]

| Name | Description |
| ---- | ----------- |
| data | *Unknown type*<br>Dictionary |

### M:StatusQuoBaseball.Base.BattingStats.LoadBattingStats(filePath)

Loads the batting stats.


#### Returns

BattingStats[]

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |

### M:StatusQuoBaseball.Base.BattingStats.LoadResultRanges(control, speed, values)

Loads the result ranges.


#### Returns

The result ranges.

| Name | Description |
| ---- | ----------- |
| control | *System.Int32*<br>int |
| speed | *System.Int32*<br>int |
| values | *System.Int32[]*<br>int[] |

### P:StatusQuoBaseball.Base.BattingStats.Name

Gets or sets the name.


### P:StatusQuoBaseball.Base.BattingStats.PowerRating

Gets or sets the power rating.


### M:StatusQuoBaseball.Base.BattingStats.RangeToString

Ranges to string.


### P:StatusQuoBaseball.Base.BattingStats.Speed

Gets or sets the speed.


### M:StatusQuoBaseball.Base.BattingStats.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.Birthday

Birthday.


### M:StatusQuoBaseball.Base.Birthday.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Base.Birthday.#ctor(birthday)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| birthday | *System.DateTime*<br>Birthday |

### M:StatusQuoBaseball.Base.Birthday.#ctor(y, m, d)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| y | *System.Int32*<br>int |
| m | *System.Int32*<br>int |
| d | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Birthday.#ctor(birthday)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| birthday | *System.String*<br>string |

### F:StatusQuoBaseball.Base.Birthday.age

The age.


### P:StatusQuoBaseball.Base.Birthday.Age

Gets the age.


### M:StatusQuoBaseball.Base.Birthday.CalculateAge(y, m, d)

Calculates the age.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| y | *System.Int32*<br>int |
| m | *System.Int32*<br>int |
| d | *System.Int32*<br>int |

### F:StatusQuoBaseball.Base.Birthday.day

The day.


### P:StatusQuoBaseball.Base.Birthday.Day

Gets the day.


### M:StatusQuoBaseball.Base.Birthday.Deconstruct(year, month, day)

Deconstruct the specified year, month and day.

| Name | Description |
| ---- | ----------- |
| year | *System.Int32@*<br>int |
| month | *System.Int32@*<br>int |
| day | *System.Int32@*<br>int |

### F:StatusQuoBaseball.Base.Birthday.Default

The default birthdate.


### F:StatusQuoBaseball.Base.Birthday.longDateString

The long date string.


### F:StatusQuoBaseball.Base.Birthday.month

The month.


### P:StatusQuoBaseball.Base.Birthday.Month

Gets the month.


### F:StatusQuoBaseball.Base.Birthday.shortDateString

The short date string.


### M:StatusQuoBaseball.Base.Birthday.ToLongDateString

Tos the long date string.


#### Returns

string


### M:StatusQuoBaseball.Base.Birthday.ToString

Returns a that represents the current .


#### Returns

string


### F:StatusQuoBaseball.Base.Birthday.year

The year.


### P:StatusQuoBaseball.Base.Birthday.Year

Gets the year.


## T:StatusQuoBaseball.Base.Coach

Represents a coach/manager.


### M:StatusQuoBaseball.Base.Coach.#ctor(personInfo, awards)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| personInfo | *StatusQuoBaseball.Loaders.PersonBasicInformation*<br>PersonBasicInformation |
| awards | *System.String[]*<br>string[] |

### M:StatusQuoBaseball.Base.Coach.#ctor(id, lName, fName, number, naturalPosition, race, handedness, bats, height, weight, birthday, awards)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>Identifier. |
| lName | *System.String*<br>string |
| fName | *System.String*<br>string |
| number | *System.String*<br>int |
| naturalPosition | *System.String*<br>string |
| race | *StatusQuoBaseball.Base.Race*<br>Race |
| handedness | *StatusQuoBaseball.Base.Handedness*<br>Handedness |
| bats | *StatusQuoBaseball.Base.Handedness*<br>Bats |
| height | *StatusQuoBaseball.Base.Height*<br>Height |
| weight | *StatusQuoBaseball.Base.Weight*<br>Weight |
| birthday | *StatusQuoBaseball.Base.Birthday*<br>Birthday |
| awards | *System.String[]*<br>string[] |

### M:StatusQuoBaseball.Base.Coach.BuildToString

Builds to string.


### P:StatusQuoBaseball.Base.Coach.CoachingAwards

Gets the coaching awards.


### P:StatusQuoBaseball.Base.Coach.CoachingStats

Gets or sets the coaching stats.


### M:StatusQuoBaseball.Base.Coach.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.CoachingStats

Coaching stats.


### M:StatusQuoBaseball.Base.CoachingStats.#ctor(managerialTendencies)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| managerialTendencies | *StatusQuoBaseball.Configuration.InMemoryConfigurationFile*<br>Managerial tendencies. |

### M:StatusQuoBaseball.Base.CoachingStats.#ctor(rating, prestige, steal2ndBase, steal3rdBase, sacrificeBunt, intentionalWalk, substituteThreshold, wins, losses)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| rating | *System.Int32*<br>int |
| prestige | *System.Int32*<br>int |
| steal2ndBase | *System.Int32*<br>int |
| steal3rdBase | *System.Int32*<br>int |
| sacrificeBunt | *System.Int32*<br>int |
| intentionalWalk | *System.Int32*<br>int |
| substituteThreshold | *System.Int32*<br>double |
| wins | *System.Int32*<br>int |
| losses | *System.Int32*<br>int |

### P:StatusQuoBaseball.Base.CoachingStats.IntentionalWalk

Gets or sets the manager's tendency to call an IBB.


### P:StatusQuoBaseball.Base.CoachingStats.Losses

Gets the losses.


### P:StatusQuoBaseball.Base.CoachingStats.MinimumStealSpeed

Gets or sets the minimum steal speed at which a coach will consider a steal


### P:StatusQuoBaseball.Base.CoachingStats.Prestige

Gets or sets the prestige of the coach.


### P:StatusQuoBaseball.Base.CoachingStats.Rating

Gets or sets the rating of the coach.


### P:StatusQuoBaseball.Base.CoachingStats.SacrificeBunt

Gets or sets the manager's tendency to call a sacrifice bunt.


### P:StatusQuoBaseball.Base.CoachingStats.Steal2ndBase

Gets or sets the manager's tendency to steal 2nd base.


### P:StatusQuoBaseball.Base.CoachingStats.Steal3rdBase

Gets or sets the manager's tendency to steal 3rd base.


### P:StatusQuoBaseball.Base.CoachingStats.SubstituteThreshold

Gets or sets the threshold at which a coach will replace a player. E.g., player stamina at 25% of original.


### M:StatusQuoBaseball.Base.CoachingStats.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Base.CoachingStats.WinLossPercentage

Gets the window loss percentage.


### P:StatusQuoBaseball.Base.CoachingStats.Wins

Gets the wins.


## T:StatusQuoBaseball.Base.ConvertTextToHandedness

Convert text to handedness.


### M:StatusQuoBaseball.Base.ConvertTextToHandedness.ConvertFromText(text)

Converts from text.


#### Returns

The from text.

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>string |

## T:StatusQuoBaseball.Base.Deathday

Deathday.


### M:StatusQuoBaseball.Base.Deathday.#ctor(deathDay)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| deathDay | *System.DateTime*<br>Deathday |

### M:StatusQuoBaseball.Base.Deathday.#ctor(y, m, d)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| y | *System.Int32*<br>int |
| m | *System.Int32*<br>int |
| d | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Deathday.#ctor(deathDay)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| deathDay | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Deathday.ToLongDateString

Tos the long date string.


#### Returns

string


### M:StatusQuoBaseball.Base.Deathday.ToString

Returns a that represents the current .


#### Returns

string


## T:StatusQuoBaseball.Base.Entity

Entity.


### M:StatusQuoBaseball.Base.Entity.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Base.Entity.#ctor(id)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>Identifier. |

### M:StatusQuoBaseball.Base.Entity.BuildToString

Builds to string.


### M:StatusQuoBaseball.Base.Entity.Clone

Clone this instance.


#### Returns

object


### M:StatusQuoBaseball.Base.Entity.Deserialize(memoryStream)

Deserialize the specified memoryStream.


#### Returns

Entity

| Name | Description |
| ---- | ----------- |
| memoryStream | *System.IO.MemoryStream*<br>MemoryStream |

### F:StatusQuoBaseball.Base.Entity.id

Id.


### P:StatusQuoBaseball.Base.Entity.Id

Gets or sets the identifier.


### M:StatusQuoBaseball.Base.Entity.Serialize

Serialize this instance.


#### Returns

MemoryStream


### M:StatusQuoBaseball.Base.Entity.SerializeToFile(filepath)

Serializes to file.


#### Returns

long

| Name | Description |
| ---- | ----------- |
| filepath | *System.String*<br>string |

### F:StatusQuoBaseball.Base.Entity.toString

Common string for all Entity-derived classes. Used to cache common to string actions.


## T:StatusQuoBaseball.Base.EntityList`1

EntityList


### M:StatusQuoBaseball.Base.EntityList`1.#ctor(id, name)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| name | *System.String*<br>string |

### M:StatusQuoBaseball.Base.EntityList`1.#ctor(id, name, items)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>Identifier. |
| name | *System.String*<br>Name. |
| items | *System.Collections.Generic.IEnumerable{`0}*<br>Items. |

### M:StatusQuoBaseball.Base.EntityList`1.BuildToString

Builds to string.


### M:StatusQuoBaseball.Base.EntityList`1.Execute

Execute this instance.


### M:StatusQuoBaseball.Base.EntityList`1.GetTotalCount``1(items)

Gets the total count.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| items | *System.Collections.Generic.IEnumerable{`0}*<br>Items |

### M:StatusQuoBaseball.Base.EntityList`1.GetTotalItemCount``1

Gets the total item count.


### F:StatusQuoBaseball.Base.EntityList`1.id

The EntityList Id.


### P:StatusQuoBaseball.Base.EntityList`1.Id

Gets the identifier.


### F:StatusQuoBaseball.Base.EntityList`1.name

The name.


### P:StatusQuoBaseball.Base.EntityList`1.Name

Gets the name.


### F:StatusQuoBaseball.Base.EntityList`1.toString

To string.


### M:StatusQuoBaseball.Base.EntityList`1.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.FieldingStatisticsContainer

Fielding statistics container.


### M:StatusQuoBaseball.Base.FieldingStatisticsContainer.#ctor(player)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| player | *StatusQuoBaseball.Base.Player*<br>Player |

### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.Assists

Gets or sets the assists.


### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.CaughtStealingPercentage

Gets the caught stealing percentage.


### M:StatusQuoBaseball.Base.FieldingStatisticsContainer.ClearStats

Clears the stats.


### M:StatusQuoBaseball.Base.FieldingStatisticsContainer.Clone

Clone this instance.


#### Returns

object


### F:StatusQuoBaseball.Base.FieldingStatisticsContainer.EmptyFieldingStatisticsContainer

The empty fielding statistics container.


### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.Errors

Gets or sets the errors.


### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.FieldingPercentage

Gets the fielding percentage.


### M:StatusQuoBaseball.Base.FieldingStatisticsContainer.LogStat(result, toIncrement)

Logs the stat.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |
| toIncrement | *System.Int32*<br>int |

### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.Putouts

Gets the putouts.


### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.StealAttemptsAgainst

Gets or sets the steal attempts against.


### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.StolenBases

Gets or sets the stolen bases.


### M:StatusQuoBaseball.Base.FieldingStatisticsContainer.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Base.FieldingStatisticsContainer.TotalChances

Gets the total chances.


## T:StatusQuoBaseball.Base.FieldingStats

Fielding stats.


### M:StatusQuoBaseball.Base.FieldingStats.#ctor(fieldingRating, groundballError, flyoutError, armStrength)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| fieldingRating | *System.Int32*<br>Fielding rating. |
| groundballError | *System.Int32*<br>Groundball error. |
| flyoutError | *System.Int32*<br>Flyout error. |
| armStrength | *System.Int32*<br>Arm strength. |

### P:StatusQuoBaseball.Base.FieldingStats.ArmStrength

Gets or sets the arm strength.


### M:StatusQuoBaseball.Base.FieldingStats.BuildToString

Builds to string.


### P:StatusQuoBaseball.Base.FieldingStats.FieldingRating

Gets the fielding rating.


### P:StatusQuoBaseball.Base.FieldingStats.FlyoutError

Gets or sets the flyout error.


### P:StatusQuoBaseball.Base.FieldingStats.GroundballError

Gets or sets the groundball error.


### M:StatusQuoBaseball.Base.FieldingStats.LoadFieldingStats(System.Collections.Generic.Dictionary{System.Int32,System.Collections.Generic.Dictionary{System.String,System.Object}})

Loads the fielding stats.


#### Returns

FieldingStats[]

| Name | Description |
| ---- | ----------- |
| data | *Unknown type*<br>Dictionary |

### M:StatusQuoBaseball.Base.FieldingStats.LoadFieldingStats(filePath)

Loads the fielding stats.


#### Returns

The fielding stats.

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>File path. |

### P:StatusQuoBaseball.Base.FieldingStats.Name

Gets or sets the name.


### P:StatusQuoBaseball.Base.FieldingStats.NaturalPosition

Gets or sets the natural position of the fielder. This field was needed to retrieve position info from the Lahman database.


### M:StatusQuoBaseball.Base.FieldingStats.RangeToString

Ranges to string.


### M:StatusQuoBaseball.Base.FieldingStats.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.FieldLocation

Field locations.


### F:StatusQuoBaseball.Base.FieldLocation.Catcher

The catcher.


### F:StatusQuoBaseball.Base.FieldLocation.CenterField

The center field.


### F:StatusQuoBaseball.Base.FieldLocation.FirstBase

The first base.


### F:StatusQuoBaseball.Base.FieldLocation.LeftField

The left field.


### F:StatusQuoBaseball.Base.FieldLocation.Pitcher

The pitcher.


### F:StatusQuoBaseball.Base.FieldLocation.RightField

The right field.


### F:StatusQuoBaseball.Base.FieldLocation.SecondBase

The second base.


### F:StatusQuoBaseball.Base.FieldLocation.Shortstop

The shortstop.


### F:StatusQuoBaseball.Base.FieldLocation.ThirdBase

The third base.


### F:StatusQuoBaseball.Base.FieldLocation.Unknown

The unknown.


## T:StatusQuoBaseball.Base.GameStatisticsDisplayer

Game statistics displayer.


### M:StatusQuoBaseball.Base.GameStatisticsDisplayer.#ctor(StatusQuoBaseball.Gameplay.Scoreboard)

Initializes a new instance of the class.


### M:StatusQuoBaseball.Base.GameStatisticsDisplayer.GetBattingStatisticsBoxScore(team)

Gets the batting statistics box score.


#### Returns

The batting statistics box score.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team. |

### M:StatusQuoBaseball.Base.GameStatisticsDisplayer.GetBoxScore

Gets the box score (score by innings) in text.


#### Returns

The box score.


### M:StatusQuoBaseball.Base.GameStatisticsDisplayer.GetFieldingStatisticsBoxScore(team)

Gets the fielding statistics box score.


#### Returns

The fielding statistics box score.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team. |

### M:StatusQuoBaseball.Base.GameStatisticsDisplayer.GetFullBoxScore

Gets the full box score.


#### Returns

string


### M:StatusQuoBaseball.Base.GameStatisticsDisplayer.GetGameStatistics

Gets the game statistics.


#### Returns

The game statistics.


### M:StatusQuoBaseball.Base.GameStatisticsDisplayer.GetPitchingStatisticsBoxScore(team)

Gets the pitching statistics box score.


#### Returns

The pitching statistics box score.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team. |

### P:StatusQuoBaseball.Base.GameStatisticsDisplayer.Scoreboard

Gets the scoreboard.


## T:StatusQuoBaseball.Base.GameStats

Game stats.


### M:StatusQuoBaseball.Base.GameStats.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Base.GameStats.BuildToString

Builds to string.


### M:StatusQuoBaseball.Base.GameStats.Clone

Clone this instance.


#### Returns

object


### F:StatusQuoBaseball.Base.GameStats.player

The player.


### P:StatusQuoBaseball.Base.GameStats.Player

Gets or sets the player.


### F:StatusQuoBaseball.Base.GameStats.range

The range.


### P:StatusQuoBaseball.Base.GameStats.Range

Gets the range.


### M:StatusQuoBaseball.Base.GameStats.RangeToString

Ranges to string. This class and FieldingStats will throw a NotImplementedException.


### F:StatusQuoBaseball.Base.GameStats.stamina

The stamina.


### P:StatusQuoBaseball.Base.GameStats.Stamina

Gets or sets the stamina.


### F:StatusQuoBaseball.Base.GameStats.toString

To string.


## T:StatusQuoBaseball.Base.Handedness

Handedness.


### F:StatusQuoBaseball.Base.Handedness.Left

Left handedness.


### F:StatusQuoBaseball.Base.Handedness.Right

Right handedness


### F:StatusQuoBaseball.Base.Handedness.Switch

Switch hitters.


### F:StatusQuoBaseball.Base.Handedness.Unknown

Unknown handedness.


## T:StatusQuoBaseball.Base.Height

Height.


### M:StatusQuoBaseball.Base.Height.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Base.Height.#ctor(inches)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| inches | *System.Int32*<br>Units. |

### M:StatusQuoBaseball.Base.Height.#ctor(height)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| height | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Height.BuildToString

Sets height to string representation.


### F:StatusQuoBaseball.Base.Height.CM_CONV

The inches to cm conversion rate.


### F:StatusQuoBaseball.Base.Height.Default

Default height.


### M:StatusQuoBaseball.Base.Height.GetAverageHeight(dataSet)

Gets the average height of a data set.


#### Returns

Height

| Name | Description |
| ---- | ----------- |
| dataSet | *StatusQuoBaseball.Base.Height[]*<br>Data set |

### P:StatusQuoBaseball.Base.Height.Inches

Gets or sets the inches.


### P:StatusQuoBaseball.Base.Height.Meters

Gets the meters.


## T:StatusQuoBaseball.Base.Measurement

Measurement.


### M:StatusQuoBaseball.Base.Measurement.#ctor

Initializes a new instance of the class.


### F:StatusQuoBaseball.Base.Measurement.metricString

The metric system string.


### M:StatusQuoBaseball.Base.Measurement.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### F:StatusQuoBaseball.Base.Measurement.units

The units.


### F:StatusQuoBaseball.Base.Measurement.useMetricSystem

Determines whether the measurement will use the metric system or not.


### P:StatusQuoBaseball.Base.Measurement.UseMetricSystem

Gets or sets a value indicating whether this use metric system.


## T:StatusQuoBaseball.Base.NullPlayer

Use this class to clear bases.


### M:StatusQuoBaseball.Base.NullPlayer.BuildToString

Builds to string.


### F:StatusQuoBaseball.Base.NullPlayer.EmptyPlayer

Represents a null or empty player.


### M:StatusQuoBaseball.Base.NullPlayer.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.OffensiveStats

Offensive stats.


## T:StatusQuoBaseball.Base.Person

Person.


### M:StatusQuoBaseball.Base.Person.#ctor(System.String,System.String,System.String,StatusQuoBaseball.Base.Race,StatusQuoBaseball.Base.Handedness,StatusQuoBaseball.Base.Height,StatusQuoBaseball.Base.Weight,StatusQuoBaseball.Base.Birthday,StatusQuoBaseball.Base.Deathday)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| lName | *System.String*<br>string |
| fName | *System.String*<br>string |
| race | *StatusQuoBaseball.Base.Race*<br>Race |
| handedness | *StatusQuoBaseball.Base.Handedness*<br>Handedness |
| height | *System.String*<br>Height |
| weight | *StatusQuoBaseball.Base.Weight*<br>Weight |
| birthday | *StatusQuoBaseball.Base.Birthday*<br>Birthday |

### M:StatusQuoBaseball.Base.Person.Age(year)

Returns the player's age in years based on the year provided.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| year | *System.Int32*<br>int |

### F:StatusQuoBaseball.Base.Person.birthday

The birthday.


### P:StatusQuoBaseball.Base.Person.Birthday

Gets the birthday of the person.


### M:StatusQuoBaseball.Base.Person.BuildToString

Builds to string.


### F:StatusQuoBaseball.Base.Person.capitalizedName

The capitalized name of the Person.


### P:StatusQuoBaseball.Base.Person.CapitalizedName

Gets the name of the capitalized.


### F:StatusQuoBaseball.Base.Person.capitalizeName

Determines whether the name of the person will be capitalized.


### P:StatusQuoBaseball.Base.Person.CapitalizeName

Gets or sets a value indicating whether this capitalize person name.


### F:StatusQuoBaseball.Base.Person.deathDate

The death date.


### P:StatusQuoBaseball.Base.Person.DeathDate

Gets the death date of the person.


#### Remarks

Returns if the person is still alive


### F:StatusQuoBaseball.Base.Person.firstName

The first name.


### P:StatusQuoBaseball.Base.Person.FirstName

Gets or sets the first name.


### F:StatusQuoBaseball.Base.Person.fullName

The full name.


### P:StatusQuoBaseball.Base.Person.FullName

Gets the full name.


### M:StatusQuoBaseball.Base.Person.GetLongestPersonName(people)

Gets the name of the longest player.


#### Returns

The longest person name.

| Name | Description |
| ---- | ----------- |
| people | *StatusQuoBaseball.Base.Person[]*<br>Person[] |

### M:StatusQuoBaseball.Base.Person.GetNameParts(name)

Gets the name parts. Example: Ken Griffey Jr.


#### Returns

Tuple

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Person.GetNameParts(name, lastNameDelimeter)

Gets the name parts as a full name Ex. Ken Griffey Jr.


#### Returns

Tuple

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>string |
| lastNameDelimeter | *System.String*<br>string  |

### F:StatusQuoBaseball.Base.Person.handedness

The handedness.


### P:StatusQuoBaseball.Base.Person.Handedness

Gets or sets the handedness.


### F:StatusQuoBaseball.Base.Person.height

The height.


### P:StatusQuoBaseball.Base.Person.Height

Gets or sets the height.


### P:StatusQuoBaseball.Base.Person.IsDeceased

Gets a value indicating whether this is deceased.


### F:StatusQuoBaseball.Base.Person.lastName

The last name.


### P:StatusQuoBaseball.Base.Person.LastName

Gets or sets the last name.


### F:StatusQuoBaseball.Base.Person.race

The race of the person.


### P:StatusQuoBaseball.Base.Person.Race

Gets or sets the race.


### M:StatusQuoBaseball.Base.Person.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### F:StatusQuoBaseball.Base.Person.weight

The weight.


### P:StatusQuoBaseball.Base.Person.Weight

Gets or sets the weight.


## T:StatusQuoBaseball.Base.PitcherTypes

Pitcher types.


### F:StatusQuoBaseball.Base.PitcherTypes.Average

Average Pitcher


### F:StatusQuoBaseball.Base.PitcherTypes.Excellent

Excellent Pitcher


### F:StatusQuoBaseball.Base.PitcherTypes.Poor

Poor pitcher.


### F:StatusQuoBaseball.Base.PitcherTypes.Unhittable

Unhittable Pitcher


### F:StatusQuoBaseball.Base.PitcherTypes.Unknown

Unknown Pitcher


## T:StatusQuoBaseball.Base.PitchingStatisticsContainer

Batting stats container.


### M:StatusQuoBaseball.Base.PitchingStatisticsContainer.#ctor(player)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| player | *StatusQuoBaseball.Base.Player*<br>Player. |

### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.AtBats

Gets or sets at bats.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Balks

Gets the balks.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.BattersFaced

Gets or sets the batters faced.


### M:StatusQuoBaseball.Base.PitchingStatisticsContainer.ClearStats

Clears the stats.


### M:StatusQuoBaseball.Base.PitchingStatisticsContainer.Clone

Clone this instance.


#### Returns

object


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.CompleteGames

Gets or sets the complete games.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Doubles

Gets or sets the doubles.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.EarnedRunAverage

Sets the earned run average.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.EarnedRunsAllowed

Gets or sets the earned runs allowed.


### F:StatusQuoBaseball.Base.PitchingStatisticsContainer.EmptyPitchingStatisticsContainer

The empty pitching statistics container.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.FieldingIndependentPitching

Gets the fielding independent pitching.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.FlyOuts

Gets or sets the fly outs.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.GroundOuts

Gets or sets the ground outs.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.HitByPitches

Gets or sets the hit by pitches.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Hits

Gets or sets the hits.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Homeruns

Gets or sets the homeruns.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.InningsPitched

Gets the innings pitched.


### M:StatusQuoBaseball.Base.PitchingStatisticsContainer.LogStat(result, toIncrement)

Logs the stat.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>Result. |
| toIncrement | *System.Int32*<br>Runs allowed. |

### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Losses

Gets or sets the losses.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.NoHitters

Gets or sets the no hitters.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.OnBasePercentageAllowed

Gets the on base percentage allowed.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.OpposingBattingAverage

Gets the opposing batting average.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.OpposingSluggingPercentage

Gets the opposing slugging percentage.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.PerfectGames

Gets or sets the perfect games.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.PitchingGamesStarted

Gets or sets the games started.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.PitchingTotalDecisions

Gets or sets the pitching total decisions.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.PitchingTotalGamesAppeared

Gets or sets the total games appeared.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.RunsAllowed

Gets the runs allowed.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.SacrificeFlyouts

Gets or sets the sacrifice flyouts.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Saves

Gets or sets the saves.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Shutouts

Gets or sets the shutouts.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Singles

Gets or sets the singles.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Strikeouts

Gets or sets the strikeouts.


### M:StatusQuoBaseball.Base.PitchingStatisticsContainer.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.TotalOuts

Gets or sets the total outs.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Triples

Gets or sets the triples.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Walks

Gets or sets the walks.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.WinLossPercentage

Gets the win-loss percentage.


### P:StatusQuoBaseball.Base.PitchingStatisticsContainer.Wins

Gets or sets the wins.


## T:StatusQuoBaseball.Base.PitchingStats

Pitching stats.


### M:StatusQuoBaseball.Base.PitchingStats.#ctor(startingControl, pitchResultData)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| startingControl | *System.Int32*<br>int |
| pitchResultData | *System.Int32[]*<br>int |

### M:StatusQuoBaseball.Base.PitchingStats.BuildToString

Builds to string.


### M:StatusQuoBaseball.Base.PitchingStats.CalculateControl(battersFaced, hits, wins, saves)

Calculates the control rating for a pitcher.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| battersFaced | *System.Int32*<br>int |
| hits | *System.Int32*<br>int |
| wins | *System.Int32*<br>int |
| saves | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.PitchingStats.CalculateStamina(startPct, wins, completeGames, totalGamesStarted, totalGamesPitched, inningsPitched)

Calculates the stamina of the pitcher.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| startPct | *System.Double*<br>double |
| wins | *System.Int32*<br>int |
| completeGames | *System.Int32*<br>int |
| totalGamesStarted | *System.Int32*<br>int |
| totalGamesPitched | *System.Int32*<br>int |
| inningsPitched | *System.Double*<br>double |

### P:StatusQuoBaseball.Base.PitchingStats.Control

Gets or sets the control.


### P:StatusQuoBaseball.Base.PitchingStats.CurrentControl

Gets or sets the current control.


### M:StatusQuoBaseball.Base.PitchingStats.EachElementIsLess(array)

Eachs the element is less.


#### Returns

true, if element is less was eached, false otherwise.

| Name | Description |
| ---- | ----------- |
| array | *System.Int32[]*<br>int[] |

### M:StatusQuoBaseball.Base.PitchingStats.FindFirstIndexOf(val, array)

Finds the first index of val.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| val | *System.Int32*<br>int |
| array | *System.Int32[]*<br>int[] |

### M:StatusQuoBaseball.Base.PitchingStats.GeneratePitchingStats(pitcherType)

Generates the pitching stats.


#### Returns

The pitching stats.

| Name | Description |
| ---- | ----------- |
| pitcherType | *StatusQuoBaseball.Base.PitcherTypes*<br>Pitcher type. |

### M:StatusQuoBaseball.Base.PitchingStats.LoadPitchingStats(System.Collections.Generic.Dictionary{System.Int32,System.Collections.Generic.Dictionary{System.String,System.Object}})

Loads the pitching stats.


#### Returns

PitchingStats[]

| Name | Description |
| ---- | ----------- |
| data | *Unknown type*<br>Data |

### M:StatusQuoBaseball.Base.PitchingStats.LoadPitchingStats(filePath)

Loads the pitching stats.


#### Returns

PitchingStats[]

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |

### M:StatusQuoBaseball.Base.PitchingStats.LoadPitchResultsRange(pitchResultData)

Loads the pitch results range.

| Name | Description |
| ---- | ----------- |
| pitchResultData | *System.Int32[]*<br>int[] |

### M:StatusQuoBaseball.Base.PitchingStats.LoadResultRanges(control, values)

Loads the result ranges.


#### Returns

PitchingStats[]

| Name | Description |
| ---- | ----------- |
| control | *System.Int32*<br>int |
| values | *System.Int32[]*<br>int[] |

### P:StatusQuoBaseball.Base.PitchingStats.Name

Gets or sets the name of the pitcher.


### P:StatusQuoBaseball.Base.PitchingStats.PitchingStatistics

Gets or sets the pitching statistics of the player for a given year.


### P:StatusQuoBaseball.Base.PitchingStats.PitchResults

Gets the pitch results.


### P:StatusQuoBaseball.Base.PitchingStats.PitchResultsRanges

Gets the pitch results ranges.


### P:StatusQuoBaseball.Base.PitchingStats.PowerRating

Gets the power rating of the pitcher. This is based on strikeouts


### M:StatusQuoBaseball.Base.PitchingStats.RangeToString

Ranges to string.


### P:StatusQuoBaseball.Base.PitchingStats.StartPct

Gets or sets the start pct.


### M:StatusQuoBaseball.Base.PitchingStats.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.PitchResults

Pitch results.


### F:StatusQuoBaseball.Base.PitchResults.Balk

Represents a balk.


### F:StatusQuoBaseball.Base.PitchResults.BB

Represents a BB.


### F:StatusQuoBaseball.Base.PitchResults.Double

Represents a double.


### F:StatusQuoBaseball.Base.PitchResults.FO

Represents a flyout.


### F:StatusQuoBaseball.Base.PitchResults.GO

Represents a groundout.


### F:StatusQuoBaseball.Base.PitchResults.HBP

Represents a HBP.


### F:StatusQuoBaseball.Base.PitchResults.HR

Represents a hr.


### F:StatusQuoBaseball.Base.PitchResults.K

Represents a K.


### F:StatusQuoBaseball.Base.PitchResults.Single

Represents a single.


### F:StatusQuoBaseball.Base.PitchResults.Triple

Represents a triple.


## T:StatusQuoBaseball.Base.Player

Player.


### M:StatusQuoBaseball.Base.Player.#ctor(personInfo)

Initializes a new instance of the class from a PersonBasicInformation struct.

| Name | Description |
| ---- | ----------- |
| personInfo | *StatusQuoBaseball.Loaders.PersonBasicInformation*<br>Person info. |

### M:StatusQuoBaseball.Base.Player.#ctor(System.String,System.String,System.String,System.String,System.String,StatusQuoBaseball.Base.Race,StatusQuoBaseball.Base.Handedness,StatusQuoBaseball.Base.Handedness,StatusQuoBaseball.Base.Height,StatusQuoBaseball.Base.Weight,StatusQuoBaseball.Base.Birthday,StatusQuoBaseball.Base.Deathday)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| lName | *System.String*<br>string |
| fName | *System.String*<br>string |
| number | *System.String*<br>string |
| naturalPosition | *System.String*<br>Natural position. |
| race | *StatusQuoBaseball.Base.Race*<br>Race |
| handedness | *StatusQuoBaseball.Base.Handedness*<br>Handedness |
| bats | *StatusQuoBaseball.Base.Handedness*<br>Handedness |
| height | *System.String*<br>Height |
| weight | *StatusQuoBaseball.Base.Weight*<br>Weight |
| birthday | *StatusQuoBaseball.Base.Birthday*<br>Birthday |

### F:StatusQuoBaseball.Base.Player.bats

The bats.


### P:StatusQuoBaseball.Base.Player.Bats

Gets the bats.


### F:StatusQuoBaseball.Base.Player.battingStatistics

The batting statistics.


### P:StatusQuoBaseball.Base.Player.BattingStatistics

Gets or sets the batting statistics.


### F:StatusQuoBaseball.Base.Player.battingStats

The batting stats.


### P:StatusQuoBaseball.Base.Player.BattingStats

Gets the batting stats.


### M:StatusQuoBaseball.Base.Player.BuildToString

Builds to string.


### F:StatusQuoBaseball.Base.Player.currentPosition

The current position.


### P:StatusQuoBaseball.Base.Player.CurrentPosition

Gets or sets the current position of the player.


### F:StatusQuoBaseball.Base.Player.currentStamina

The current stamina.


### P:StatusQuoBaseball.Base.Player.CurrentStamina

Gets or sets the current stamina of the player.


### F:StatusQuoBaseball.Base.Player.fieldingStatistics

The fielding statistics.


### P:StatusQuoBaseball.Base.Player.FieldingStatistics

Gets or sets the fielding statistics.


### F:StatusQuoBaseball.Base.Player.fieldingStats

The fielding stats.


### P:StatusQuoBaseball.Base.Player.FieldingStats

Gets the fielding stats.


### F:StatusQuoBaseball.Base.Player.isBatting

Whether or not the player is batting.


### P:StatusQuoBaseball.Base.Player.IsBatting

Gets or sets a value indicating whether this is batting.


### F:StatusQuoBaseball.Base.Player.isRunning

The player is running.


### P:StatusQuoBaseball.Base.Player.IsRunning

Gets or sets a value indicating whether this is running.


### F:StatusQuoBaseball.Base.Player.madeAppearance

The made appearance.


### P:StatusQuoBaseball.Base.Player.MadeAppearance

Gets or sets whether the player made an appearance in the game.


### F:StatusQuoBaseball.Base.Player.naturalPosition

The natural position.


### P:StatusQuoBaseball.Base.Player.NaturalPosition

Gets or sets the natural position of the player


### F:StatusQuoBaseball.Base.Player.number

The number.


### P:StatusQuoBaseball.Base.Player.Number

Gets or sets the number.


### M:StatusQuoBaseball.Base.Player.OnPlayerStaminaReduced(e)

Ons the player stamina reduced.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Base.PlayerStaminaReducedEventArgs*<br>PlayerStaminaReducedEventArgs |

### F:StatusQuoBaseball.Base.Player.pitchingStatistics

The pitching statistics.


### P:StatusQuoBaseball.Base.Player.PitchingStatistics

Gets or sets the pitching statistics.


### F:StatusQuoBaseball.Base.Player.pitchingStats

The pitching stats.


### P:StatusQuoBaseball.Base.Player.PitchingStats

Gets or sets the pitching stats.


### E:StatusQuoBaseball.Base.Player.PlayerStaminaReduced

Occurs when player stamina reduced.


### F:StatusQuoBaseball.Base.Player.seasonStatistics

The season statistics.


### P:StatusQuoBaseball.Base.Player.SeasonStatistics

Gets the season statistics.


### F:StatusQuoBaseball.Base.Player.showExtendedToString

The show extended to string.


### P:StatusQuoBaseball.Base.Player.ShowExtendedToString

Gets or sets a value indicating whether this show extended to string.


### F:StatusQuoBaseball.Base.Player.stamina

The stamina.


### P:StatusQuoBaseball.Base.Player.Stamina

Gets or sets the stamina.


### F:StatusQuoBaseball.Base.Player.team

The team.


### P:StatusQuoBaseball.Base.Player.Team

Gets or sets the team.


### F:StatusQuoBaseball.Base.Player.throws

The throws.


### P:StatusQuoBaseball.Base.Player.Throws

Gets the throws.


### M:StatusQuoBaseball.Base.Player.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### F:StatusQuoBaseball.Base.Player.uniform

The uniform.


### P:StatusQuoBaseball.Base.Player.Uniform

Gets or sets the uniform.


### F:StatusQuoBaseball.Base.Player.year

The year of this player.


### P:StatusQuoBaseball.Base.Player.Year

Gets or sets the year.


## T:StatusQuoBaseball.Base.PlayerStaminaReducedEventArgs

Player Stamina Reduced event arguments.


### M:StatusQuoBaseball.Base.PlayerStaminaReducedEventArgs.#ctor(player)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| player | *StatusQuoBaseball.Base.Player*<br>Player |

### P:StatusQuoBaseball.Base.PlayerStaminaReducedEventArgs.Player

Gets the player.


## T:StatusQuoBaseball.Base.PlayerStaminaReducedEventHandler

Player Stamina Reduced event handler.


## T:StatusQuoBaseball.Base.Positions

Positions.


### F:StatusQuoBaseball.Base.Positions.PositionNames

The position names.


## T:StatusQuoBaseball.Base.Race

Race.


### F:StatusQuoBaseball.Base.Race.Asian

Asian


### F:StatusQuoBaseball.Base.Race.Black

Black


### F:StatusQuoBaseball.Base.Race.Hispanic

Hispanic


### F:StatusQuoBaseball.Base.Race.Other

Other


### F:StatusQuoBaseball.Base.Race.Unknown

Unknown race.


### F:StatusQuoBaseball.Base.Race.White

White


## T:StatusQuoBaseball.Base.RaceFactory

Factory to generate race.


### M:StatusQuoBaseball.Base.RaceFactory.GetRaceFromText(text)

Gets the race of a player from text.


#### Returns

Race

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>string |

## T:StatusQuoBaseball.Base.Rankings`1

Rankings.


### M:StatusQuoBaseball.Base.Rankings`1.#ctor(players, categoryHeader, categoryName)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| players | *StatusQuoBaseball.Base.Player[]*<br>Player[] |
| categoryHeader | *System.String*<br>string |
| categoryName | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Rankings`1.#ctor(root, categoryHeader, categoryName)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| root | *StatusQuoBaseball.Base.TeamGroupTree*<br>TeamGroupTree |
| categoryHeader | *System.String*<br>string |
| categoryName | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Rankings`1.BuildToString

Builds to string.


### P:StatusQuoBaseball.Base.Rankings`1.CategoryHeader

Gets the category header.


### P:StatusQuoBaseball.Base.Rankings`1.CategoryName

Gets the name of the category.


### M:StatusQuoBaseball.Base.Rankings`1.GetIndividualPlayersFromLeague(league)

Gets the individual players from league.

| Name | Description |
| ---- | ----------- |
| league | *StatusQuoBaseball.Base.TeamGroupTree*<br>TeamGroupTree |


#### Returns

Player[]


### M:StatusQuoBaseball.Base.Rankings`1.GetIndividualPlayersFromTeams(teams)

Gets the individual players from an array of teams.


#### Returns

Player[]

| Name | Description |
| ---- | ----------- |
| teams | *StatusQuoBaseball.Base.Team[]*<br>Team |

### P:StatusQuoBaseball.Base.Rankings`1.RankedPlayers

Gets the ranked players.


### M:StatusQuoBaseball.Base.Rankings`1.Sort(sorter, n)

Sort the specified sorter. Returns top N players based on the RankingSorter provided.


#### Returns

Player[]

| Name | Description |
| ---- | ----------- |
| sorter | *StatusQuoBaseball.Base.RankingSorters.RankingSorter*<br>RankingSorter |
| n | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Rankings`1.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.RankingSorters.RankingSorter

Ranking sorter.


### M:StatusQuoBaseball.Base.RankingSorters.RankingSorter.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortBattingAverageAscending

Sort batting average ascending.


### M:StatusQuoBaseball.Base.RankingSorters.SortBattingAverageAscending.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortBattingAverageDescending

Sort batting average descending.


### M:StatusQuoBaseball.Base.RankingSorters.SortBattingAverageDescending.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortBattingByHits

Sort batting average ascending.


### M:StatusQuoBaseball.Base.RankingSorters.SortBattingByHits.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortBattingByHomeruns

Sort batting average ascending.


### M:StatusQuoBaseball.Base.RankingSorters.SortBattingByHomeruns.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortBattingByRBI

Sort batting average ascending.


### M:StatusQuoBaseball.Base.RankingSorters.SortBattingByRBI.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortBattingByStolenBases

Sort batting average ascending.


### M:StatusQuoBaseball.Base.RankingSorters.SortBattingByStolenBases.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortPitchingByERAAscending

Sort by wins descending.


### M:StatusQuoBaseball.Base.RankingSorters.SortPitchingByERAAscending.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortPitchingByERADescending

Sort by wins descending.


### M:StatusQuoBaseball.Base.RankingSorters.SortPitchingByERADescending.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortPitchingByStrikeouts

Sort by wins descending.


### M:StatusQuoBaseball.Base.RankingSorters.SortPitchingByStrikeouts.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RankingSorters.SortPitchingByWins

Sort by wins descending.


### M:StatusQuoBaseball.Base.RankingSorters.SortPitchingByWins.Compare(x, y)

Compare the specified x and y.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| x | *StatusQuoBaseball.Base.Player*<br>Player |
| y | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.Roster

Roster.


### M:StatusQuoBaseball.Base.Roster.#ctor(team, players)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |
| players | *StatusQuoBaseball.Base.Player[]*<br>Player [] |

### P:StatusQuoBaseball.Base.Roster.AvailablePlayers

Gets the available players (who have not made an appearance).


### P:StatusQuoBaseball.Base.Roster.Bullpen

Gets or sets the bullpen.


### M:StatusQuoBaseball.Base.Roster.CalculateRosterBatterRating(n)

Calculates the roster batter rating. This is based on the top N rated hitters on the team.

| Name | Description |
| ---- | ----------- |
| n | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Roster.CalculateRosterPitchingControl(n)

Calculates the roster pitching control based on the top N pitchers.

| Name | Description |
| ---- | ----------- |
| n | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Roster.CalculateRosterPowerRating(n)

Calculates the roster power rating. This is based on the top N power hitters on the team.

| Name | Description |
| ---- | ----------- |
| n | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Roster.CalculateRosterSpeedRating(n)

Calculates the roster power rating.

| Name | Description |
| ---- | ----------- |
| n | *System.Int32*<br>int |

### P:StatusQuoBaseball.Base.Roster.CurrentPitcher

Gets or sets the current pitcher.


### M:StatusQuoBaseball.Base.Roster.GetNextAvailablePlayer(lastIndex, list)

Gets the next available player.


#### Returns

Player

| Name | Description |
| ---- | ----------- |
| lastIndex | *System.Int32*<br>int |
| list | *StatusQuoBaseball.Base.Player[]*<br>Player[] |

### M:StatusQuoBaseball.Base.Roster.GetPlayerAtPosition(position)

Gets the player at position.


#### Returns

Player

| Name | Description |
| ---- | ----------- |
| position | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Roster.GetStarter(position)

Gets the starter for a position.


#### Returns

Player

| Name | Description |
| ---- | ----------- |
| position | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Roster.GetStartingPitcher(System.Int32)

Gets the starting pitcher. Will choose between the top N pitchers provided


#### Returns

Player


### M:StatusQuoBaseball.Base.Roster.GetTopNPlayers(position, n)

Returns top N players of a position. This is needed because the Lahman database doesn't distinguish between the different types of outfield positions.


#### Returns

Player[]

| Name | Description |
| ---- | ----------- |
| position | *System.String*<br>string |
| n | *System.Int32*<br>int |

### P:StatusQuoBaseball.Base.Roster.Lineup

Gets or sets the lineup.


### P:StatusQuoBaseball.Base.Roster.PitchingOrder

Gets the pitching order.


### P:StatusQuoBaseball.Base.Roster.Players

Gets or sets the players.


### P:StatusQuoBaseball.Base.Roster.PositionPlayers

Gets or sets the position players.


### M:StatusQuoBaseball.Base.Roster.RankPitchersByControl(pitchers)

Ranks the pitchers by control.


#### Returns

List(Player)

| Name | Description |
| ---- | ----------- |
| pitchers | *StatusQuoBaseball.Base.Player[]*<br>Player[] |

### M:StatusQuoBaseball.Base.Roster.RankPitchersByStamina(StatusQuoBaseball.Base.Player[])

Ranks the pitchers by stamina.


### M:StatusQuoBaseball.Base.Roster.RankPositionPlayersByBatterRating

Ranks the position players by batter rating.


### P:StatusQuoBaseball.Base.Roster.RosterBatterRating

Gets the roster batter rating.


### P:StatusQuoBaseball.Base.Roster.RosterControl

Gets the roster control.


### P:StatusQuoBaseball.Base.Roster.RosterPowerPitching

Gets the roster power pitching.


### P:StatusQuoBaseball.Base.Roster.RosterPowerRating

Gets the roster power rating.


### P:StatusQuoBaseball.Base.Roster.RosterSize

Gets the size of the roster.


### P:StatusQuoBaseball.Base.Roster.RosterSpeedRating

Gets the roster speed rating.


### E:StatusQuoBaseball.Base.Roster.RosterSubstitutionEventHandled

Occurs when roster substitution event handled.


### M:StatusQuoBaseball.Base.Roster.SetBullpen

Sets the bullpen and also chooses the starting pitcher.


### M:StatusQuoBaseball.Base.Roster.SetStartingLineup

Sets the starting lineup.


### M:StatusQuoBaseball.Base.Roster.SetStartingPitchers(n)

Sets the starting pitchers.

| Name | Description |
| ---- | ----------- |
| n | *System.Int32*<br>int |

### P:StatusQuoBaseball.Base.Roster.StartingPitchers

Gets or sets the starting pitchers.


### M:StatusQuoBaseball.Base.Roster.SubstitutePlayer(outgoingPlayer)

Substitutes the player.


#### Returns

Player

| Name | Description |
| ---- | ----------- |
| outgoingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Base.RosterSubstitutionEventArgs

Roster substitution event arguments.


### M:StatusQuoBaseball.Base.RosterSubstitutionEventArgs.#ctor(outgoing, incoming)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| outgoing | *StatusQuoBaseball.Base.Player*<br>Player |
| incoming | *StatusQuoBaseball.Base.Player*<br>Player |

### P:StatusQuoBaseball.Base.RosterSubstitutionEventArgs.Incoming

Gets the player being inserted into the lineup.


### P:StatusQuoBaseball.Base.RosterSubstitutionEventArgs.Outgoing

Gets the player being removed.


## T:StatusQuoBaseball.Base.RosterSubstitutionEventHandler

Roster substitution event handler.


## T:StatusQuoBaseball.Base.SabermetricsPitchingStatisticsContainer

Sabermetrics pitching statistics container.


### M:StatusQuoBaseball.Base.SabermetricsPitchingStatisticsContainer.#ctor(person)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| person | *StatusQuoBaseball.Base.Person*<br>Person. |

### M:StatusQuoBaseball.Base.SabermetricsPitchingStatisticsContainer.ClearStats

This is not implemented


### M:StatusQuoBaseball.Base.SabermetricsPitchingStatisticsContainer.Clone

Clone this instance.


#### Returns

object


### P:StatusQuoBaseball.Base.SabermetricsPitchingStatisticsContainer.FieldingIndependentPitching

Gets the fielding independent pitching.


### M:StatusQuoBaseball.Base.SabermetricsPitchingStatisticsContainer.LogStat(result, toIncrement)

This is not implemented.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |
| toIncrement | *System.Int32*<br>int |

## T:StatusQuoBaseball.Base.SeasonStatisticalLeaders

Season statistical leaders.


### M:StatusQuoBaseball.Base.SeasonStatisticalLeaders.BuildToString

Builds to string.


## T:StatusQuoBaseball.Base.SeasonStatisticsContainer

Season statistics container.


### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.#ctor(person)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| person | *StatusQuoBaseball.Base.Person*<br>Person. |

### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.AggregateBattingStatistics(gameBattingStatistics)

Aggregates the batting statistics.

| Name | Description |
| ---- | ----------- |
| gameBattingStatistics | *StatusQuoBaseball.Base.BattingStatisticsContainer*<br>BattingStatisticsContainer |

### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.AggregateFieldingStatistics(gameFieldingStatistics)

Aggregates the fielding statistics.

| Name | Description |
| ---- | ----------- |
| gameFieldingStatistics | *StatusQuoBaseball.Base.FieldingStatisticsContainer*<br>FieldingStatisticsContainer |

### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.AggregatePitchingStatistics(gamePitchingStatistics, gameInningsPitched)

Aggregates the pitching statistics.

| Name | Description |
| ---- | ----------- |
| gamePitchingStatistics | *StatusQuoBaseball.Base.PitchingStatisticsContainer*<br>PitchingStatisticsContainer |
| gameInningsPitched | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.ClearStats

Clears the stats.


### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.Clone

Clone this instance.


#### Returns

object


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.GameBattingStatistics

Gets the individual game batting statistics of the player.


### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.gameBattingStats

The season batting stats.


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.GameFieldingStatistics

Gets the individual game fielding statistics of the player.


### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.gameFieldingStats

The game fielding stats.


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.GamePitchingStatistics

Gets the individual game pitching statistics of the player.


### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.gamePitchingStats

The game pitching stats.


### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.LogGameStats(gameStatisticsToLog, gameInningsPitched)

Logs the game stats.

| Name | Description |
| ---- | ----------- |
| gameStatisticsToLog | *StatusQuoBaseball.Base.StatisticsContainer*<br>StatisticsContainer |
| gameInningsPitched | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.SeasonStatisticsContainer.LogStat(result, toIncrement)

Will throw System.NotImplementedException. Use LogGameStats instead.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>Result. |
| toIncrement | *System.Int32*<br>To increment. |

### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.seasonBattingStatistics

The season batting statistics.


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.SeasonBattingStatistics

Gets the season batting statistics.


### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.seasonFieldingStatistics

The season fielding statistics.


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.SeasonFieldingStatistics

Gets the season fielding statistics.


### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.seasonPitchingStatistics

The season pitching statistics.


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.SeasonPitchingStatistics

Gets the season pitching statistics.


### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.totalGamesPlayed

The total games played.


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.TotalGamesPlayed

Gets or sets the total games played.


### F:StatusQuoBaseball.Base.SeasonStatisticsContainer.totalGamesStarted

The total games started.


### P:StatusQuoBaseball.Base.SeasonStatisticsContainer.TotalGamesStarted

Gets or sets the total games started.


## T:StatusQuoBaseball.Base.SeasonStatisticsDisplayer

Season statistics displayer.


### M:StatusQuoBaseball.Base.SeasonStatisticsDisplayer.#ctor(team)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |

### M:StatusQuoBaseball.Base.SeasonStatisticsDisplayer.GetSeasonBattingStatistics

Gets the season batting statistics.


#### Returns

string


### M:StatusQuoBaseball.Base.SeasonStatisticsDisplayer.GetSeasonFieldingStatistics

Gets the season fielding statistics.


#### Returns

string


### M:StatusQuoBaseball.Base.SeasonStatisticsDisplayer.GetSeasonPitchingStatistics

Gets the season pitching statistics.


#### Returns

string


### M:StatusQuoBaseball.Base.SeasonStatisticsDisplayer.GetTeamInformation

Gets the team information.


#### Returns

string


### P:StatusQuoBaseball.Base.SeasonStatisticsDisplayer.Team

Gets the team.


## T:StatusQuoBaseball.Base.Standings

Standings.


### M:StatusQuoBaseball.Base.Standings.#ctor(teams)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| teams | *StatusQuoBaseball.Base.Team[]*<br>Team[] |

### M:StatusQuoBaseball.Base.Standings.BuildToString

Builds to string.


### M:StatusQuoBaseball.Base.Standings.GetStandings(teams)

Gets the standings from a RoundRobin or season.


#### Returns

Standings

| Name | Description |
| ---- | ----------- |
| teams | *StatusQuoBaseball.Base.Team[]*<br>Teams[] |

### P:StatusQuoBaseball.Base.Standings.Teams

Gets the teams.


### M:StatusQuoBaseball.Base.Standings.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.StatisticsContainer

Statistics container.


### M:StatusQuoBaseball.Base.StatisticsContainer.#ctor(person)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| person | *StatusQuoBaseball.Base.Person*<br>Person |

### M:StatusQuoBaseball.Base.StatisticsContainer.#ctor(person, game)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| person | *StatusQuoBaseball.Base.Person*<br>Person |
| game | *StatusQuoBaseball.Gameplay.Game*<br>Game |

### M:StatusQuoBaseball.Base.StatisticsContainer.ClearStats

Clears the stats.


### M:StatusQuoBaseball.Base.StatisticsContainer.Clone

Clone this instance. This is necessary to save a copy of each game's statistics in season mode.


#### Returns

object


### F:StatusQuoBaseball.Base.StatisticsContainer.game

The game.


### P:StatusQuoBaseball.Base.StatisticsContainer.Game

Gets or sets the game associated with this statistics container


### M:StatusQuoBaseball.Base.StatisticsContainer.LogStat(StatusQuoBaseball.Gameplay.GamePlayResult,System.Int32)

Logs the stat.


### F:StatusQuoBaseball.Base.StatisticsContainer.person

The person.


### P:StatusQuoBaseball.Base.StatisticsContainer.Person

Gets or sets the person.


## T:StatusQuoBaseball.Base.Team

Represents a collection of players.


### M:StatusQuoBaseball.Base.Team.#ctor(name, mascot, coach, year)

Initializes a new instance of the class


#### Remarks

If a year is not entered, the current year will be assumed.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>Name |
| mascot | *System.String*<br>Mascot |
| coach | *StatusQuoBaseball.Base.Coach*<br>Coach |
| year | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Team.#ctor(name, mascot, year)

Initializes a new instance of the class.


#### Remarks

If a year is not entered, the current year will be assumed.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>Name |
| mascot | *System.String*<br>Mascot |
| year | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Team.AddGameToTeamStatistics(game)

Adds the game to team stats.

| Name | Description |
| ---- | ----------- |
| game | *StatusQuoBaseball.Gameplay.Game*<br>Game |

### M:StatusQuoBaseball.Base.Team.BuildToString

Builds to string.


### P:StatusQuoBaseball.Base.Team.CapitalizeNames

Gets or sets a value indicating whether this capitalize names.


### P:StatusQuoBaseball.Base.Team.Coach

Getsthe coach of the team.


### P:StatusQuoBaseball.Base.Team.Displayer

Gets or sets the displayer.


### M:StatusQuoBaseball.Base.Team.GetAllPlayers(StatusQuoBaseball.Base.Team[])

Gets all players from an array of teams.


#### Returns

Player[]


### M:StatusQuoBaseball.Base.Team.GetTeamNameParts(franchiseName)

Gets the team name parts.


#### Returns

ValueTuple(string,string)

| Name | Description |
| ---- | ----------- |
| franchiseName | *System.String[]*<br>string[] |

### M:StatusQuoBaseball.Base.Team.LoadTeamFromDatabase(searchTerm, year, capitalizeNames)

Loads the team from database.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| searchTerm | *System.String*<br>string |
| year | *System.Int32*<br>int |
| capitalizeNames | *System.Boolean*<br>If set to true capitalize names. |

### P:StatusQuoBaseball.Base.Team.Mascot

Gets the mascot of the team.


### P:StatusQuoBaseball.Base.Team.Name

Gets the name of the team.


### M:StatusQuoBaseball.Base.Team.OnPlayerStaminaReduced(e)

Ons the player stamina reduced.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Base.PlayerStaminaReducedEventArgs*<br>PlayerStaminaReducedEventArgs |

### M:StatusQuoBaseball.Base.Team.OnRosterSubstitution(e)

Ons the roster substitution.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Base.RosterSubstitutionEventArgs*<br>RosterSubstitutionEventArgs |

### P:StatusQuoBaseball.Base.Team.RawName

Gets the raw name of the team (e.g., no years or other information)


### P:StatusQuoBaseball.Base.Team.Roster

Gets the roster of the team.


### P:StatusQuoBaseball.Base.Team.SeasonStatisticsContainer

Gets or sets the season statistics container.


### P:StatusQuoBaseball.Base.Team.ShowExtendedToString

Gets or sets a value indicating whether this show extended to string.


### M:StatusQuoBaseball.Base.Team.SubsitutePlayer(p)

Subsitutes the player.

| Name | Description |
| ---- | ----------- |
| p | *StatusQuoBaseball.Base.Player*<br>Player |

### E:StatusQuoBaseball.Base.Team.TeamActionEventHandled

Occurs when team action event handled.


### M:StatusQuoBaseball.Base.Team.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Base.Team.Year

Gets or sets the year of the team.


## T:StatusQuoBaseball.Base.TeamActionEventArgs

Team action event arguments.


### M:StatusQuoBaseball.Base.TeamActionEventArgs.#ctor(team, msg)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |
| msg | *System.String*<br>string |

### P:StatusQuoBaseball.Base.TeamActionEventArgs.Msg

Gets the message.


### P:StatusQuoBaseball.Base.TeamActionEventArgs.Team

Gets the team doing the action.


## T:StatusQuoBaseball.Base.TeamActionEventHandler

Team action event handler.


## T:StatusQuoBaseball.Base.TeamGroup

Team group.


### M:StatusQuoBaseball.Base.TeamGroup.#ctor(id, name)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| name | *System.String*<br>name |

### M:StatusQuoBaseball.Base.TeamGroup.#ctor(id, name, items)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| name | *System.String*<br>string |
| items | *System.Collections.Generic.IEnumerable{StatusQuoBaseball.Base.Team}*<br>List |

### M:StatusQuoBaseball.Base.TeamGroup.BuildToString

Returns a that represents the current .


#### Returns

A that represents the current .


### M:StatusQuoBaseball.Base.TeamGroup.Execute

Execute this instance.


### M:StatusQuoBaseball.Base.TeamGroup.GetAllPlayers

Gets all players from all teams in the team group.


#### Returns

Player[]


### M:StatusQuoBaseball.Base.TeamGroup.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.TeamGroupTree

Team group.


### M:StatusQuoBaseball.Base.TeamGroupTree.#ctor(id, name, seriesLength)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| name | *System.String*<br>string |
| seriesLength | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.TeamGroupTree.BuildToString

Builds to string.


### M:StatusQuoBaseball.Base.TeamGroupTree.Execute

Execute this instance.


### M:StatusQuoBaseball.Base.TeamGroupTree.GetAllPlayers

Gets all players from all teams in the TeamGroupTree.


#### Returns

Player[]


### M:StatusQuoBaseball.Base.TeamGroupTree.LogStandings(teamGroup)

Logs the season stats.

| Name | Description |
| ---- | ----------- |
| teamGroup | *StatusQuoBaseball.Base.TeamGroup*<br>TeamGroup |

### M:StatusQuoBaseball.Base.TeamGroupTree.ReportProgress(e)

Reports the progress of the round robin.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.ProgressReporterEventArgs*<br>ProgressReporterEventArgs |

### M:StatusQuoBaseball.Base.TeamGroupTree.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.TeamInfoDisplayer

Team info displayer.


### M:StatusQuoBaseball.Base.TeamInfoDisplayer.#ctor(theTeam)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| theTeam | *StatusQuoBaseball.Base.Team*<br>The team. |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetBattingStatistics(players, showRanges)

Gets the batting statistics.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| players | *System.Boolean*<br>Players[] |
| showRanges | *StatusQuoBaseball.Base.Player[]*<br>If set to true show ranges. |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetBattingStatisticsHeader(personnel)

Gets the batting statistics header.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| personnel | *StatusQuoBaseball.Base.Person[]*<br>Person[] |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetFieldingStatistics(players)

Gets the fielding statistics.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| players | *StatusQuoBaseball.Base.Player[]*<br>Players[] |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetFieldingStatisticsHeader(personnel)

Gets the fielding statistics header.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| personnel | *StatusQuoBaseball.Base.Person[]*<br>Person[] |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetIndividualStats(player, showRanges)

Gets the individual stats.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| player | *StatusQuoBaseball.Base.Player*<br>Player |
| showRanges | *System.Boolean*<br>bool |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetPitchingStatistics(showRanges, players)

Gets the pitching statistics.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| showRanges | *System.Boolean*<br>If set to true show ranges. |
| players | *StatusQuoBaseball.Base.Player[]*<br>Players[] |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetPitchingStatisticsHeader(personnel)

Gets the pitching statistics header.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| personnel | *StatusQuoBaseball.Base.Person[]*<br>People[] |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetTeamInformation

Gets the team information (Team Name, Mascot, and Coach)


#### Returns

string


### M:StatusQuoBaseball.Base.TeamInfoDisplayer.GetTeamStats(showRanges)

Gets the team stats.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| showRanges | *System.Boolean*<br>If set to true show ranges. |

### M:StatusQuoBaseball.Base.TeamInfoDisplayer.Log

Log this instance.


### P:StatusQuoBaseball.Base.TeamInfoDisplayer.Team

Gets or sets the team.


### P:StatusQuoBaseball.Base.TeamInfoDisplayer.TeamInformation

Gets the team information.


## T:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer

Team season statistics container.


### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.#ctor(player)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| player | *StatusQuoBaseball.Base.Player*<br>Player. |

### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.#ctor(team)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |

### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.AggregateBattingStatistics(gameBattingStatistics)

Aggregates the batting statistics.

| Name | Description |
| ---- | ----------- |
| gameBattingStatistics | *StatusQuoBaseball.Base.BattingStatisticsContainer*<br>Game batting statistics. |

### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.AggregateFieldingStatistics(gameFieldingStatistics)

Aggregates the fielding statistics.

| Name | Description |
| ---- | ----------- |
| gameFieldingStatistics | *StatusQuoBaseball.Base.FieldingStatisticsContainer*<br>Game fielding statistics. |

### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.AggregatePitchingStatistics(gamePitchingStatistics, gameInningsPitched)

Aggregates the pitching statistics.

| Name | Description |
| ---- | ----------- |
| gamePitchingStatistics | *StatusQuoBaseball.Base.PitchingStatisticsContainer*<br>Game pitching statistics. |
| gameInningsPitched | *System.Int32*<br>Game innings pitched. |

### P:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.BattingAverage

Gets the batting average.


### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.ClearStats

Clears the stats.


### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.Clone

Clone this instance.


#### Returns

object


### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.LogStat(result, toIncrement)

Logs the stat.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |
| toIncrement | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.LogTeamGameStats(System.Int32,System.Boolean)

Logs the game stats for the team


### P:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.Losses

Gets the losses.


### M:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.WinLossPercentage

Gets the win-loss percentage.


### P:StatusQuoBaseball.Base.TeamSeasonStatisticsContainer.Wins

Gets the wins.


## T:StatusQuoBaseball.Base.Uniform

Uniform.


### M:StatusQuoBaseball.Base.Uniform.#ctor(name, number)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>Name. |
| number | *System.String*<br>Number. |

### M:StatusQuoBaseball.Base.Uniform.#ctor(firstName, lastName, number)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| firstName | *System.String*<br>string |
| lastName | *System.String*<br>string |
| number | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Uniform.BuildToString

Builds to string.


### P:StatusQuoBaseball.Base.Uniform.LastName

Gets or sets the last name.


### P:StatusQuoBaseball.Base.Uniform.Name

Gets or sets the name.


### P:StatusQuoBaseball.Base.Uniform.Number

Gets or sets the number.


### M:StatusQuoBaseball.Base.Uniform.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.UniformsLoader

Uniforms loader.


### M:StatusQuoBaseball.Base.UniformsLoader.LoadUniformsFromFile(filePath)

Loads the fielding stats.


#### Returns

Uniform[]

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |

## T:StatusQuoBaseball.Base.Venue

Venue.


### M:StatusQuoBaseball.Base.Venue.#ctor(game, id, capacity, name, location)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| game | *StatusQuoBaseball.Gameplay.Game*<br>Game |
| id | *System.String*<br>string |
| capacity | *System.Int32*<br>int |
| name | *System.String*<br>string |
| location | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Venue.#ctor(id, capacity, name, location)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| capacity | *System.Int32*<br>int |
| name | *System.String*<br>string |
| location | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Venue.BuildToString

Builds to string.


### P:StatusQuoBaseball.Base.Venue.Capacity

Gets the capacity.


### P:StatusQuoBaseball.Base.Venue.Game

Gets the game.


### F:StatusQuoBaseball.Base.Venue.GenericVenue

Represents a generic venue or stadium. Returned if a stadium for a team is not found in a database or file.


### P:StatusQuoBaseball.Base.Venue.Location

Gets the location of the venue.


### P:StatusQuoBaseball.Base.Venue.Name

Gets the name of the venue.


### M:StatusQuoBaseball.Base.Venue.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Base.VenueManager

Loads venues from a CSV file. At the moment, the CSV file is more complete than the Lahman database.


### M:StatusQuoBaseball.Base.VenueManager.GetVenue(teamName)

Gets the venue.


#### Returns

Venue

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>Team name. |

### M:StatusQuoBaseball.Base.VenueManager.Init(filePath, hasHeaderRows)

Loads all venues from a file.

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |
| hasHeaderRows | *System.Boolean*<br>bool |

### M:StatusQuoBaseball.Base.VenueManager.LoadVenuesFromFile(filePath, hasHeaderRow)

Loads all venues from file.

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |
| hasHeaderRow | *System.Boolean*<br>If set to true has header row. |

### P:StatusQuoBaseball.Base.VenueManager.VenueCount

Gets the venue count.


## T:StatusQuoBaseball.Base.Weight

Weight.


### M:StatusQuoBaseball.Base.Weight.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Base.Weight.#ctor(pounds)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| pounds | *System.Int32*<br>int |

### M:StatusQuoBaseball.Base.Weight.#ctor(pounds)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| pounds | *System.String*<br>string |

### M:StatusQuoBaseball.Base.Weight.BuildToString

Sets weight to string representation.


### F:StatusQuoBaseball.Base.Weight.Default

The default weight.


### M:StatusQuoBaseball.Base.Weight.GetAverageWeight(dataSet, useMetricSystem)

Gets the average weight of a data set.


#### Returns

Weight

| Name | Description |
| ---- | ----------- |
| dataSet | *StatusQuoBaseball.Base.Weight[]*<br>Weight[] |
| useMetricSystem | *System.Boolean*<br>bool |

### F:StatusQuoBaseball.Base.Weight.KG_CONVERTER

The lbs to kg conversion rate.


### P:StatusQuoBaseball.Base.Weight.Kilograms

Gets the kilograms.


### P:StatusQuoBaseball.Base.Weight.Pounds

Gets the pounds.


## T:StatusQuoBaseball.Configuration.ConfigurationManager

Configuration reader and Manager


### M:StatusQuoBaseball.Configuration.ConfigurationManager.#ctor

Initializes a new instance of the class.


### P:StatusQuoBaseball.Configuration.ConfigurationManager.Count

Gets the number of config files being managed.


### M:StatusQuoBaseball.Configuration.ConfigurationManager.GetConfigFileSize(fileName)

Gets the number of lines in a particular config file.


#### Returns

The config file size.

| Name | Description |
| ---- | ----------- |
| fileName | *System.String*<br>File name. |

### M:StatusQuoBaseball.Configuration.ConfigurationManager.GetConfigurationValue(key)

Gets the value for the key in a configuration manager with only one config file.

| Name | Description |
| ---- | ----------- |
| key | *System.String*<br>string |


#### Returns

string


### M:StatusQuoBaseball.Configuration.ConfigurationManager.GetConfigurationValue(fileName, key)

Gets the configuration value when the configuration manager has multiple config files.


#### Returns

The configuration value.

| Name | Description |
| ---- | ----------- |
| fileName | *System.String*<br>string |
| key | *System.String*<br>string |

### M:StatusQuoBaseball.Configuration.ConfigurationManager.GetInMemoryConfigFile(filePath, delimiter)

Can be used to return info from files that are in k=v format, without maintaining information in the ConfigurationManager.


#### Returns

InMemoryConfigurationFile

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |
| delimiter | *System.Char*<br>char |

### M:StatusQuoBaseball.Configuration.ConfigurationManager.Init(configFilePath, delimiter, commentChar)

Initializes the ConfigReader with a single config file.

| Name | Description |
| ---- | ----------- |
| configFilePath | *System.String*<br>string |
| delimiter | *System.Char*<br>char |
| commentChar | *System.Char*<br>char |

### M:StatusQuoBaseball.Configuration.ConfigurationManager.Init(configFilePath, delimiter, secondDelimeter)

Initializes the configuration manager with multiple config files.

| Name | Description |
| ---- | ----------- |
| configFilePath | *System.String[]*<br>string[] |
| delimiter | *System.Char*<br>char |
| secondDelimeter | *System.Char*<br>char |

## T:StatusQuoBaseball.Configuration.ConfigurationManagerException

Configuration manager exception.


### M:StatusQuoBaseball.Configuration.ConfigurationManagerException.#ctor(msg, innerException)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| msg | *System.String*<br>string |
| innerException | *System.Exception*<br>Exception |

## T:StatusQuoBaseball.Configuration.InMemoryConfigurationFile

In memory configuration file.


### M:StatusQuoBaseball.Configuration.InMemoryConfigurationFile.#ctor(System.Collections.Generic.IDictionary{System.String,System.Object})

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| dictionary | *Unknown type*<br>Dictionary |

### M:StatusQuoBaseball.Configuration.InMemoryConfigurationFile.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Database.Db

Database.


### M:StatusQuoBaseball.Database.Db.#ctor(connection)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| connection | *System.String*<br>string |

### M:StatusQuoBaseball.Database.Db.Close

Close this instance.


### P:StatusQuoBaseball.Database.Db.ConnectionString

Gets the connection string.


### M:StatusQuoBaseball.Database.Db.ExecuteQuery(procedure)

Executes a stored procedure.


#### Returns

SQLQueryResult

| Name | Description |
| ---- | ----------- |
| procedure | *StatusQuoBaseball.Database.SQLStoredProcedure*<br>SQLStoredProcedure |

### M:StatusQuoBaseball.Database.Db.ExecuteQuery(sql)

Executes the sql query and returns the number of rows.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| sql | *System.String*<br>string |

### P:StatusQuoBaseball.Database.Db.IsConnected

Gets a value indicating whether this is connected.


## T:StatusQuoBaseball.Database.SQLDataRow

SQLD ata row.


### M:StatusQuoBaseball.Database.SQLDataRow.#ctor(builder)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| builder | *System.Data.DataRowBuilder*<br>DataRowBuilder |

## T:StatusQuoBaseball.Database.SQLDataSet

SQL data set.


### M:StatusQuoBaseball.Database.SQLDataSet.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Database.SQLDataSet.#ctor(dataSetName)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| dataSetName | *System.String*<br>string |

## T:StatusQuoBaseball.Database.SQLDataTable

SQL Data table.


### M:StatusQuoBaseball.Database.SQLDataTable.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Database.SQLDataTable.#ctor(info, context)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| info | *System.Runtime.Serialization.SerializationInfo*<br>Info. |
| context | *System.Runtime.Serialization.StreamingContext*<br>Context. |

### M:StatusQuoBaseball.Database.SQLDataTable.#ctor(tableName)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| tableName | *System.String*<br>Table name. |

### M:StatusQuoBaseball.Database.SQLDataTable.#ctor(tableName, tableNamespace)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| tableName | *System.String*<br>Table name. |
| tableNamespace | *System.String*<br>Table namespace. |

### M:StatusQuoBaseball.Database.SQLDataTable.LoadWithoutConstraints(reader, tableName)

Load the specified reader, loadOption and errorHandler.

| Name | Description |
| ---- | ----------- |
| reader | *System.Data.IDataReader*<br>IDataReader |
| tableName | *System.String*<br>string |

## T:StatusQuoBaseball.Database.SQLNonQueryResult

SQL non query result.


### M:StatusQuoBaseball.Database.SQLNonQueryResult.#ctor(rowsAffected, sqlStatement)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| rowsAffected | *System.Int32*<br>int |
| sqlStatement | *System.String*<br>string |

## T:StatusQuoBaseball.Database.SQLQueryResult

SQL query result.


### M:StatusQuoBaseball.Database.SQLQueryResult.#ctor(sqlStatement, dataTable)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| sqlStatement | *System.String*<br>string |
| dataTable | *StatusQuoBaseball.Database.SQLDataTable*<br>SQLDataTable |

### P:StatusQuoBaseball.Database.SQLQueryResult.DataTable

Gets the data set.


## T:StatusQuoBaseball.Database.SQLStatementResult

SQL Statement result.


### M:StatusQuoBaseball.Database.SQLStatementResult.#ctor(rowsAffected, sqlStatement)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| rowsAffected | *System.Int32*<br>int |
| sqlStatement | *System.String*<br>string |

### F:StatusQuoBaseball.Database.SQLStatementResult.rowsAffected

The rows affected.


### P:StatusQuoBaseball.Database.SQLStatementResult.RowsAffected

Gets the rows affected.


### F:StatusQuoBaseball.Database.SQLStatementResult.sqlStatement

The sql statement.


### P:StatusQuoBaseball.Database.SQLStatementResult.SqlStatement

Gets the sql statement.


## T:StatusQuoBaseball.Database.SQLStoredProcedure

Sqlite stored procedure.


### M:StatusQuoBaseball.Database.SQLStoredProcedure.#ctor(filePath, parameters)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |
| parameters | *System.Object[]*<br>object[] |

### M:StatusQuoBaseball.Database.SQLStoredProcedure.#ctor(filePath, name)

Stored procedures end with .sql

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |
| name | *System.String*<br>string |

### M:StatusQuoBaseball.Database.SQLStoredProcedure.AddParametersToSQLText(path, queryParameters)

Adds the parameters to SQLStoredProcedure Text.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| path | *System.String*<br>string |
| queryParameters | *System.Object[]*<br>object[] |

### M:StatusQuoBaseball.Database.SQLStoredProcedure.Clone

Returns a clone of the SQLStoredProcedure. Otherwise, procedures in the StoredProcedureManager will have their parameters modified.


#### Returns

object


### P:StatusQuoBaseball.Database.SQLStoredProcedure.FilePath

Gets the file path.


### P:StatusQuoBaseball.Database.SQLStoredProcedure.Name

Gets the name.


### P:StatusQuoBaseball.Database.SQLStoredProcedure.Parameters

Gets or sets the parameters of the SQLStoredProcedure.


### M:StatusQuoBaseball.Database.SQLStoredProcedure.ReadSQLFromFile(path)

Reads the SQLF rom file.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| path | *System.String*<br>string |

### P:StatusQuoBaseball.Database.SQLStoredProcedure.Text

Gets the text.


### M:StatusQuoBaseball.Database.SQLStoredProcedure.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Database.StoredProcedureManager

Stored procedure manager.


### P:StatusQuoBaseball.Database.StoredProcedureManager.Count

Gets the count.


### M:StatusQuoBaseball.Database.StoredProcedureManager.Get(name)

Get the StoredProcedure.


#### Returns

SQLStoredProcedure

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>string |

### M:StatusQuoBaseball.Database.StoredProcedureManager.Init(directory)

Init the specified directory.

| Name | Description |
| ---- | ----------- |
| directory | *System.String*<br>string |

## T:StatusQuoBaseball.Gameplay.Announcer

Announcer.


### M:StatusQuoBaseball.Gameplay.Announcer.#ctor(id, name, game)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| name | *System.String*<br>string |
| game | *StatusQuoBaseball.Gameplay.Game*<br>Game |

### M:StatusQuoBaseball.Gameplay.Announcer.#ctor(id, name, logger)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>string |
| name | *System.String*<br>string |
| logger | *StatusQuoBaseball.Utilities.Logger*<br>Logger |

### M:StatusQuoBaseball.Gameplay.Announcer.AnnounceToConsole(msg)

Announces to console. If a logger was included at initialization, the msg will be logged as well.

| Name | Description |
| ---- | ----------- |
| msg | *System.String*<br>string |

### M:StatusQuoBaseball.Gameplay.Announcer.BuildToString

Builds to string.


### P:StatusQuoBaseball.Gameplay.Announcer.Game

Gets or sets the game.


### P:StatusQuoBaseball.Gameplay.Announcer.Name

Gets or sets the name.


### P:StatusQuoBaseball.Gameplay.Announcer.Silent

Gets or sets a value indicating whether this is silent. If set to " true," game commentary will only be logged (if a logger is attached).


### M:StatusQuoBaseball.Gameplay.Announcer.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.AtBat

At bat.


### M:StatusQuoBaseball.Gameplay.AtBat.#ctor(batter, pitcher, inning)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| batter | *StatusQuoBaseball.Base.Player*<br>Batter |
| pitcher | *StatusQuoBaseball.Base.Player*<br>Pitcher |
| inning | *StatusQuoBaseball.Gameplay.Inning*<br>Inning |

### M:StatusQuoBaseball.Gameplay.AtBat.ApplyPlayerAdjustments

Applies the player adjustments.


### P:StatusQuoBaseball.Gameplay.AtBat.Batter

Gets the batter.


### M:StatusQuoBaseball.Gameplay.AtBat.Execute

Execute the at bat.


### E:StatusQuoBaseball.Gameplay.AtBat.gamePlayResultHandled

Occurs when game play result handled.


### P:StatusQuoBaseball.Gameplay.AtBat.Inning

Gets the inning.


### M:StatusQuoBaseball.Gameplay.AtBat.OnGamePlayResult(res)

On the game play result.

| Name | Description |
| ---- | ----------- |
| res | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |

### P:StatusQuoBaseball.Gameplay.AtBat.Pitcher

Gets the pitcher.


### P:StatusQuoBaseball.Gameplay.AtBat.Result

Gets the result.


## T:StatusQuoBaseball.Gameplay.Balk

Balk.


### M:StatusQuoBaseball.Gameplay.Balk.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Balk.Execute

Execute this instance.


## T:StatusQuoBaseball.Gameplay.Base

Base.


### M:StatusQuoBaseball.Gameplay.Base.#ctor(index, name)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| index | *System.Int32*<br>int |
| name | *System.String*<br>string |

### M:StatusQuoBaseball.Gameplay.Base.ClearBase

Clears the base.


### P:StatusQuoBaseball.Gameplay.Base.CurrentBaserunner

Gets or sets the current baserunner.


### P:StatusQuoBaseball.Gameplay.Base.Index

Gets the index of the base.


### P:StatusQuoBaseball.Gameplay.Base.IsOccupied

Gets a value indicating whether this is occupied.


### P:StatusQuoBaseball.Gameplay.Base.IsVacant

Gets a value indicating whether this is empty.


### P:StatusQuoBaseball.Gameplay.Base.Name

Gets the name.


### M:StatusQuoBaseball.Gameplay.Base.PlaceRunnerOnBase(baseRunner)

Places the runner on base.

| Name | Description |
| ---- | ----------- |
| baseRunner | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Base.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Bases

Bases.


### M:StatusQuoBaseball.Gameplay.Bases.#ctor

Initializes a new instance of the class.


### P:StatusQuoBaseball.Gameplay.Bases.AreEmpty

Gets a value indicating whether this are empty.


### P:StatusQuoBaseball.Gameplay.Bases.AreLoaded

Gets a value indicating whether this are loaded.


## T:StatusQuoBaseball.Gameplay.Bases.Assist

Assist.


### M:StatusQuoBaseball.Gameplay.Bases.Assist.#ctor(game, inning, outType, bases)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| game | *StatusQuoBaseball.Gameplay.Game*<br>Game |
| inning | *StatusQuoBaseball.Gameplay.Inning*<br>Inning |
| outType | *StatusQuoBaseball.Gameplay.Out*<br>OutType |
| bases | *StatusQuoBaseball.Gameplay.Bases*<br>Bases |

### P:StatusQuoBaseball.Gameplay.Bases.Assist.AssistChain

Gets the assist chain.


### P:StatusQuoBaseball.Gameplay.Bases.Assist.Bases

Gets the bases.


### M:StatusQuoBaseball.Gameplay.Bases.Assist.Execute

Execute this instance.


### P:StatusQuoBaseball.Gameplay.Bases.Assist.Game

Gets the game.


### P:StatusQuoBaseball.Gameplay.Bases.Assist.OutType

Gets the type of the out.


### M:StatusQuoBaseball.Gameplay.Bases.Assist.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### M:StatusQuoBaseball.Gameplay.Bases.ClearBases

Clears the bases.


### P:StatusQuoBaseball.Gameplay.Bases.FirstBase

Gets the first base.


### P:StatusQuoBaseball.Gameplay.Bases.HomePlate

Gets the home plate.


### P:StatusQuoBaseball.Gameplay.Bases.Item(System.Int32)

Sets the at the specified index.

| Name | Description |
| ---- | ----------- |
| index | *System.Int32*<br>Index. |

### M:StatusQuoBaseball.Gameplay.Bases.OnRunScored(team, runner, batter, pitcher, result)

On the run scored.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |
| runner | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |
| pitcher | *StatusQuoBaseball.Base.Player*<br>Player |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |

### M:StatusQuoBaseball.Gameplay.Bases.PlaceBatter(team, batter, pitcher, result)

Places the batter.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team. |
| batter | *StatusQuoBaseball.Base.Player*<br>Batter. |
| pitcher | *StatusQuoBaseball.Base.Player*<br>Pitcher. |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>Result. |

### M:StatusQuoBaseball.Gameplay.Bases.PushOtherBaserunners(team, batter, pitcher, totalBases, result)

Pushes the other baserunners.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |
| pitcher | *StatusQuoBaseball.Base.Player*<br>Player |
| totalBases | *System.Int32*<br>int |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |

### E:StatusQuoBaseball.Gameplay.Bases.runScoredEventHandled

Occurs when run scored event handled.


### P:StatusQuoBaseball.Gameplay.Bases.SecondBase

Gets the second base.


### M:StatusQuoBaseball.Gameplay.Bases.SetBases

Sets the bases.


### P:StatusQuoBaseball.Gameplay.Bases.ThirdBase

Gets the third base.


### M:StatusQuoBaseball.Gameplay.Bases.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.DeepFlyOut

Deep fly out.


### M:StatusQuoBaseball.Gameplay.DeepFlyOut.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Controlling player. |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Non controlling player. |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.DeepFlyOut.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.DeepFlyOut.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Double

Double.


### M:StatusQuoBaseball.Gameplay.Double.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Double.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.Double.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Error

Error.


### M:StatusQuoBaseball.Gameplay.Error.#ctor(StatusQuoBaseball.Base.Player,StatusQuoBaseball.Gameplay.Out,StatusQuoBaseball.Base.Player,StatusQuoBaseball.Base.Player,StatusQuoBaseball.Base.Player)

Initializes a new instance of the class.


### M:StatusQuoBaseball.Gameplay.Error.Execute

Execute this instance.


### P:StatusQuoBaseball.Gameplay.Error.Fielder

Gets the fielder.


### P:StatusQuoBaseball.Gameplay.Error.OutType

Gets the type of the out.


### M:StatusQuoBaseball.Gameplay.Error.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Flyout

Flyout.


### M:StatusQuoBaseball.Gameplay.Flyout.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Flyout.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.Flyout.GetFieldLocation

Gets the field location.


#### Returns

FieldLocation


### M:StatusQuoBaseball.Gameplay.Flyout.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Game

Game


### M:StatusQuoBaseball.Gameplay.Game.#ctor(venue, roadTeam, homeTeam, gameTime, maxInnings, isSeasonMode)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| venue | *StatusQuoBaseball.Base.Venue*<br>Venue |
| roadTeam | *StatusQuoBaseball.Base.Team*<br>Team |
| homeTeam | *StatusQuoBaseball.Base.Team*<br>Team |
| gameTime | *System.String*<br>string |
| maxInnings | *System.Int32*<br>int |
| isSeasonMode | *System.Boolean*<br>bool |

### M:StatusQuoBaseball.Gameplay.Game.AddInning

Adds the inning.


### P:StatusQuoBaseball.Gameplay.Game.Announcer

Gets or sets the announcer.


### M:StatusQuoBaseball.Gameplay.Game.AssignWinningPitcher(roadPitcher, homePitcher)

Assigns the winning pitcher.

| Name | Description |
| ---- | ----------- |
| roadPitcher | *StatusQuoBaseball.Base.Player*<br>Team |
| homePitcher | *StatusQuoBaseball.Base.Player*<br>Team |

### P:StatusQuoBaseball.Gameplay.Game.Bases

Gets the bases.


### M:StatusQuoBaseball.Gameplay.Game.BuildToString

Builds to string.


### M:StatusQuoBaseball.Gameplay.Game.ClearGameStats(team)

Clears the game stats.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team. |

### M:StatusQuoBaseball.Gameplay.Game.ConductEndOfGame

Conducts the end of game.


### P:StatusQuoBaseball.Gameplay.Game.CurrentInning

Gets the current inning.


### M:StatusQuoBaseball.Gameplay.Game.Execute

Play this instance.


### P:StatusQuoBaseball.Gameplay.Game.GameOver

Gets a value indicating whether this game over.


### P:StatusQuoBaseball.Gameplay.Game.GamesPlayedInSeason

Gets the games played in season.


### P:StatusQuoBaseball.Gameplay.Game.GameTime

Gets or sets the game time.


### M:StatusQuoBaseball.Gameplay.Game.GenerateGameTime

Generates the game time.


#### Returns

string


### P:StatusQuoBaseball.Gameplay.Game.HomeTeam

Gets or sets the home team.


### P:StatusQuoBaseball.Gameplay.Game.Innings

Gets the innings.


### M:StatusQuoBaseball.Gameplay.Game.IsGameOver

Ises the game over.


#### Returns

true, if game over was ised, false otherwise.


### P:StatusQuoBaseball.Gameplay.Game.IsInExtraInnings

Gets or sets a value indicating whether this is in extra innings.


### P:StatusQuoBaseball.Gameplay.Game.IsSeasonMode

Gets or sets a value indicating whether this is season mode.


### P:StatusQuoBaseball.Gameplay.Game.LastHomeTeamBatter

Gets the last home team batter.


### P:StatusQuoBaseball.Gameplay.Game.LastRoadTeamBatter

Gets the last road team batter.


### P:StatusQuoBaseball.Gameplay.Game.Loser

Gets the loser.


### M:StatusQuoBaseball.Gameplay.Game.OnGamePlayResultHandled(e)

Ons the game play result handled.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.GamePlayResultEventArgs*<br>E. |

### M:StatusQuoBaseball.Gameplay.Game.OnInningActionHandled(e)

Ons the inning action handled.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.InningActionEventArgs*<br>E. |

### M:StatusQuoBaseball.Gameplay.Game.OnRunScored(e)

Ons the run scored.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.RunScoredEventArgs*<br>E. |

### M:StatusQuoBaseball.Gameplay.Game.OnTeamActionEventHandled(e)

Ons the team action event handled.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Base.TeamActionEventArgs*<br>TeamActionEventArgs |

### P:StatusQuoBaseball.Gameplay.Game.RoadTeam

Gets or sets the road team.


### P:StatusQuoBaseball.Gameplay.Game.Scoreboard

Gets the scoreboard.


### M:StatusQuoBaseball.Gameplay.Game.SignalGameOver

Signals the game over.


### M:StatusQuoBaseball.Gameplay.Game.ToggleInning

Toggles the inning.


### M:StatusQuoBaseball.Gameplay.Game.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### M:StatusQuoBaseball.Gameplay.Game.UpdateSeasonStatistics(team)

Updates the season statistics.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |

### P:StatusQuoBaseball.Gameplay.Game.Venue

Gets or sets the venue.


### P:StatusQuoBaseball.Gameplay.Game.Winner

Gets the winner.


## T:StatusQuoBaseball.Gameplay.GamePlayResult

Game play result.


### M:StatusQuoBaseball.Gameplay.GamePlayResult.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### F:StatusQuoBaseball.Gameplay.GamePlayResult.batter

The batter.


### P:StatusQuoBaseball.Gameplay.GamePlayResult.Batter

Gets the batter.


### F:StatusQuoBaseball.Gameplay.GamePlayResult.controllingPlayer

The controlling player.


### P:StatusQuoBaseball.Gameplay.GamePlayResult.ControllingPlayer

Gets the controlling player.


### M:StatusQuoBaseball.Gameplay.GamePlayResult.DetermineBatter

Determines the batter.


### M:StatusQuoBaseball.Gameplay.GamePlayResult.Execute

Execute this instance.


### F:StatusQuoBaseball.Gameplay.GamePlayResult.nonControllingPlayer

The non controlling player.


### P:StatusQuoBaseball.Gameplay.GamePlayResult.NonControllingPlayer

Gets the non controlling player.


### F:StatusQuoBaseball.Gameplay.GamePlayResult.pitcher

The pitcher.


### P:StatusQuoBaseball.Gameplay.GamePlayResult.Pitcher

Gets the pitcher.


## T:StatusQuoBaseball.Gameplay.GamePlayResultEventArgs

Game play result event arguments.


### M:StatusQuoBaseball.Gameplay.GamePlayResultEventArgs.#ctor(result)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |

### P:StatusQuoBaseball.Gameplay.GamePlayResultEventArgs.GamePlayResult

Gets the game play result.


## T:StatusQuoBaseball.Gameplay.GamePlayResultEventHandler

Game play result event handler.


## T:StatusQuoBaseball.Gameplay.GamePlayResultFactory

Game play result factory.


### M:StatusQuoBaseball.Gameplay.GamePlayResultFactory.GetResult(currentAtBat, result)

Gets the result.


#### Returns

GamePlayResult

| Name | Description |
| ---- | ----------- |
| currentAtBat | *StatusQuoBaseball.Gameplay.AtBat*<br>AtBat |
| result | *StatusQuoBaseball.Base.BattingResults*<br>GamePlayResult |

### M:StatusQuoBaseball.Gameplay.GamePlayResultFactory.GetResult(currentAtBat, result)

Gets the result.


#### Returns

GamePlayResult

| Name | Description |
| ---- | ----------- |
| currentAtBat | *StatusQuoBaseball.Gameplay.AtBat*<br>AtBat |
| result | *StatusQuoBaseball.Base.PitchResults*<br>GamePlayResult |

## T:StatusQuoBaseball.Gameplay.GroundOut

Ground out.


### M:StatusQuoBaseball.Gameplay.GroundOut.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Controlling player. |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Non controlling player. |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.GroundOut.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.GroundOut.GetFieldLocation

Gets the field location.


#### Returns

FieldLocation


### M:StatusQuoBaseball.Gameplay.GroundOut.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Hit

Hit.


### M:StatusQuoBaseball.Gameplay.Hit.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Controlling player. |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Non controlling player. |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

## T:StatusQuoBaseball.Gameplay.HitByPitch

Hit by pitch.


### M:StatusQuoBaseball.Gameplay.HitByPitch.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.HitByPitch.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.HitByPitch.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.HomeRun

Home run.


### M:StatusQuoBaseball.Gameplay.HomeRun.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.HomeRun.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.HomeRun.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.IExecutable

IExecutable.


### M:StatusQuoBaseball.Gameplay.IExecutable.Execute

Execute this instance.


## T:StatusQuoBaseball.Gameplay.Inning

Inning.


### M:StatusQuoBaseball.Gameplay.Inning.#ctor(inningNumber, game)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| inningNumber | *System.Int32*<br>int |
| game | *StatusQuoBaseball.Gameplay.Game*<br>Game |

### P:StatusQuoBaseball.Gameplay.Inning.BottomOfInningNotPlayed

Gets or sets a value indicating whether this bottom of inning not played.


### M:StatusQuoBaseball.Gameplay.Inning.CheckStealAttempt(coach)

Checks for steal attempt.

| Name | Description |
| ---- | ----------- |
| coach | *StatusQuoBaseball.Base.Coach*<br>Coach |

### P:StatusQuoBaseball.Gameplay.Inning.CurrentAtBat

Gets the current at bat.


### P:StatusQuoBaseball.Gameplay.Inning.CurrentOut

Gets the current out.


### M:StatusQuoBaseball.Gameplay.Inning.DoSteal(coach)

Does the steal attempt.

| Name | Description |
| ---- | ----------- |
| coach | *StatusQuoBaseball.Base.Coach*<br>Coach |

### M:StatusQuoBaseball.Gameplay.Inning.EndOfInning(StatusQuoBaseball.Gameplay.GamePlayResult)

Ends the inning.


### M:StatusQuoBaseball.Gameplay.Inning.Execute

Execute this instance.


### P:StatusQuoBaseball.Gameplay.Inning.FieldingTeam

Gets or sets the fielding team.


### P:StatusQuoBaseball.Gameplay.Inning.Game

Gets the game.


### E:StatusQuoBaseball.Gameplay.Inning.GamePlayResultHandled

Occurs when game play result handled.


### E:StatusQuoBaseball.Gameplay.Inning.InningActionHandled

Occurs when inning action handled.


### P:StatusQuoBaseball.Gameplay.Inning.InningNumber

Gets the inning number.


### P:StatusQuoBaseball.Gameplay.Inning.IsInningOver

Gets or sets a value indicating whether this is inning over.


### P:StatusQuoBaseball.Gameplay.Inning.IsTopOfInning

Gets a value indicating whether this is top of inning.


### M:StatusQuoBaseball.Gameplay.Inning.OnGamePlayResultHandled(result)

Ons the game play result handled.

| Name | Description |
| ---- | ----------- |
| result | *StatusQuoBaseball.Gameplay.GamePlayResultEventArgs*<br>GamePlayResultEventArgs |

### M:StatusQuoBaseball.Gameplay.Inning.OnInningAction(toggleInning, _isInningOver, result)

Ons the inning action.

| Name | Description |
| ---- | ----------- |
| toggleInning | *System.Boolean*<br>If set to true toggle inning. |
| _isInningOver | *System.Boolean*<br>If set to true is inning over. |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>Result. |

### M:StatusQuoBaseball.Gameplay.Inning.OnStealAttemptHandled(e)

On the steal attempt handled.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.StealAttemptEventArgs*<br>StealAttemptEventArgs |

### P:StatusQuoBaseball.Gameplay.Inning.TeamAtBat

Gets or sets the team at bat.


### M:StatusQuoBaseball.Gameplay.Inning.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.InningActionEventArgs

Inning action event arguments.


### M:StatusQuoBaseball.Gameplay.InningActionEventArgs.#ctor(inning, toggleInning, isInningOver, result)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| inning | *StatusQuoBaseball.Gameplay.Inning*<br>Inning |
| toggleInning | *System.Boolean*<br>If set to true toggle inning. |
| isInningOver | *System.Boolean*<br>bool |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |

### P:StatusQuoBaseball.Gameplay.InningActionEventArgs.GamePlayResult

Gets the game play result.


### P:StatusQuoBaseball.Gameplay.InningActionEventArgs.Inning

Gets the inning.


### P:StatusQuoBaseball.Gameplay.InningActionEventArgs.IsInningOver

Gets a value indicating whether this is inning over.


### P:StatusQuoBaseball.Gameplay.InningActionEventArgs.ToggleInning

Gets or sets a value indicating whether this toggle inning.


## T:StatusQuoBaseball.Gameplay.InningActionEventHandler

Inning action event handler.


## T:StatusQuoBaseball.Gameplay.InningScore

Inning score.


### P:StatusQuoBaseball.Gameplay.InningScore.BottomErrors

Gets or sets the bottom errors.


### P:StatusQuoBaseball.Gameplay.InningScore.BottomHits

Gets or sets the bottom hits.


### P:StatusQuoBaseball.Gameplay.InningScore.BottomScore

Gets or sets the bottom score.


### P:StatusQuoBaseball.Gameplay.InningScore.TopErrors

Gets or sets the top errors.


### P:StatusQuoBaseball.Gameplay.InningScore.TopHits

Gets or sets the top hits.


### P:StatusQuoBaseball.Gameplay.InningScore.TopScore

Gets or sets the top score.


## T:StatusQuoBaseball.Gameplay.IProgressReporter

Progress reporter.


### M:StatusQuoBaseball.Gameplay.IProgressReporter.ReportProgress

Reports the progress.


## T:StatusQuoBaseball.Gameplay.OtherResult

Other result.


### M:StatusQuoBaseball.Gameplay.OtherResult.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.OtherResult.Execute

Execute this instance.


## T:StatusQuoBaseball.Gameplay.Out

Out.


### M:StatusQuoBaseball.Gameplay.Out.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Out.CheckForError

Checks for error.


### M:StatusQuoBaseball.Gameplay.Out.Execute

Execute this instance.


### P:StatusQuoBaseball.Gameplay.Out.Fielder

Gets the fielder.


### M:StatusQuoBaseball.Gameplay.Out.GetFielder(positionOfFielder, pitcher)

Gets the fielder.


#### Returns

Player

| Name | Description |
| ---- | ----------- |
| positionOfFielder | *System.String*<br>string |
| pitcher | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Out.GetFieldLocation

Gets the field location.


#### Returns

The field location.


### F:StatusQuoBaseball.Gameplay.Out.InfieldOutLocations

The infield out locations.


### P:StatusQuoBaseball.Gameplay.Out.IsError

Gets a value indicating whether this is error.


### F:StatusQuoBaseball.Gameplay.Out.outLocation

The out location.


### P:StatusQuoBaseball.Gameplay.Out.OutLocation

Gets the out location.


## T:StatusQuoBaseball.Gameplay.PopFlyOut

Pop fly out.


### M:StatusQuoBaseball.Gameplay.PopFlyOut.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.PopFlyOut.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.PopFlyOut.GetFieldLocation

Gets the field location of the pop fly out.


#### Returns

FieldLocation


### M:StatusQuoBaseball.Gameplay.PopFlyOut.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.ProgressReporterEventArgs

Steal attempt event arguments.


### M:StatusQuoBaseball.Gameplay.ProgressReporterEventArgs.#ctor(numGames, gamesPlayed, nameOfEvent)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| numGames | *System.Int32*<br>int |
| gamesPlayed | *System.Int32*<br>int |
| nameOfEvent | *System.String*<br>string |

### P:StatusQuoBaseball.Gameplay.ProgressReporterEventArgs.GamesPlayed

Gets the games played.


### P:StatusQuoBaseball.Gameplay.ProgressReporterEventArgs.NameOfEvent

Gets the name of event.


### P:StatusQuoBaseball.Gameplay.ProgressReporterEventArgs.NumGames

Gets the number games.


### P:StatusQuoBaseball.Gameplay.ProgressReporterEventArgs.Progress

Gets the progress of the RoundRobin.


## T:StatusQuoBaseball.Gameplay.ProgressReporterEventHandler

Round robin progress event handler.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.StealAttemptEventArgs*<br>RoundRobinProgressEventArgs |

## T:StatusQuoBaseball.Gameplay.RoundRobin

Round robin scheduler


### M:StatusQuoBaseball.Gameplay.RoundRobin.#ctor(seriesLength, isSilentMode, logSeasonStats, logSeasonStandings, interval, teams)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| seriesLength | *System.Int32*<br>int |
| isSilentMode | *System.Boolean*<br>bool |
| logSeasonStats | *System.Boolean*<br>bool |
| logSeasonStandings | *System.Boolean*<br>bool |
| interval | *System.Int32*<br>int |
| teams | *StatusQuoBaseball.Base.Team[]*<br>Team[] |

### M:StatusQuoBaseball.Gameplay.RoundRobin.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.RoundRobin.GenerateRoundRobin(num_teams)

Generates the round robin.


#### Returns

int[,]

| Name | Description |
| ---- | ----------- |
| num_teams | *System.Int32*<br>int |

### M:StatusQuoBaseball.Gameplay.RoundRobin.GenerateRoundRobinEven(num_teams)

Generates the round robin even.


#### Returns

int[,]

| Name | Description |
| ---- | ----------- |
| num_teams | *System.Int32*<br>int |

### M:StatusQuoBaseball.Gameplay.RoundRobin.GenerateRoundRobinOdd(num_teams)

Generates the round robin odd.


#### Returns

int[,]

| Name | Description |
| ---- | ----------- |
| num_teams | *System.Int32*<br>int |

### P:StatusQuoBaseball.Gameplay.RoundRobin.IsSilentMode

Gets a value indicating whether this is silent mode.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogBattingAverageRankings

Logs the batting average rankings.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogHitRankings

Logs the hit rankings.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogHomeRunRankings

Logs the home run rankings.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogRankings

Logs the rankings.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogRBIRankings

Logs the RBI Rankings.


### P:StatusQuoBaseball.Gameplay.RoundRobin.LogSeasonStandings

Gets or sets a value indicating whether this log season standings.


### P:StatusQuoBaseball.Gameplay.RoundRobin.LogSeasonStats

Gets or sets a value indicating whether this log season stats.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogStandings

Logs the standings.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogStats

Logs the season stats.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogStolenBasesRankings

Logs the stolen bases rankings.


### M:StatusQuoBaseball.Gameplay.RoundRobin.LogStrikeoutRankings

Logs the stolen bases rankings.


### M:StatusQuoBaseball.Gameplay.RoundRobin.OnRoundRobinProgressHandled(gamesPlayed)

Ons the round robin progress handled.

| Name | Description |
| ---- | ----------- |
| gamesPlayed | *System.Int32*<br>int |

### M:StatusQuoBaseball.Gameplay.RoundRobin.ReportProgress

Reports the progress.


### M:StatusQuoBaseball.Gameplay.RoundRobin.ReportSeriesProgress(e)

Reports the series progress.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.ProgressReporterEventArgs*<br>ProgressReporterEventArgs |

### M:StatusQuoBaseball.Gameplay.RoundRobin.RotateArray(teamIndices)

Rotates the array.


#### Remarks

Rotate the entries one position.

| Name | Description |
| ---- | ----------- |
| teamIndices | *System.Int32[]*<br>int[] |

### E:StatusQuoBaseball.Gameplay.RoundRobin.RoundRobinProgressHandled

Occurs when round robin progress handled.


### P:StatusQuoBaseball.Gameplay.RoundRobin.SeriesLength

Gets the length of each series in the round robin.


### P:StatusQuoBaseball.Gameplay.RoundRobin.Teams

Gets the teams.


### M:StatusQuoBaseball.Gameplay.RoundRobin.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Gameplay.RoundRobin.TotalGamesPlayed

Gets the total games played.


### P:StatusQuoBaseball.Gameplay.RoundRobin.TotalGamesToPlay

Gets the total games to play.


## T:StatusQuoBaseball.Gameplay.RunScoredEventArgs

Run scored event arguments.


### M:StatusQuoBaseball.Gameplay.RunScoredEventArgs.#ctor(team, runner, batter, pitcher, result)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |
| runner | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |
| pitcher | *StatusQuoBaseball.Base.Player*<br>Player |
| result | *StatusQuoBaseball.Gameplay.GamePlayResult*<br>GamePlayResult |

### P:StatusQuoBaseball.Gameplay.RunScoredEventArgs.Batter

Gets or sets the batter.


### P:StatusQuoBaseball.Gameplay.RunScoredEventArgs.Pitcher

Gets or sets the pitcher.


### P:StatusQuoBaseball.Gameplay.RunScoredEventArgs.Result

Gets or sets the result.


### P:StatusQuoBaseball.Gameplay.RunScoredEventArgs.Runner

Gets the runner.


### P:StatusQuoBaseball.Gameplay.RunScoredEventArgs.Team

Gets the team.


## T:StatusQuoBaseball.Gameplay.RunScoredEventHandler

Run scored event handler.


## T:StatusQuoBaseball.Gameplay.SacrificeFly

Sacrifice fly.


### M:StatusQuoBaseball.Gameplay.SacrificeFly.#ctor(inning, controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| inning | *StatusQuoBaseball.Gameplay.Inning*<br>Inning |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.SacrificeFly.Execute

Execute this instance. Outs and stats are already logged in the DeepFlyOut class.Sacrifice fly only handles the base runner movement.


### M:StatusQuoBaseball.Gameplay.SacrificeFly.GetFieldLocation

Gets the field location of the pop fly out.


#### Returns

FieldLocation


### M:StatusQuoBaseball.Gameplay.SacrificeFly.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Scoreboard

Scoreboard.


### M:StatusQuoBaseball.Gameplay.Scoreboard.#ctor(game, roadTeam, homeTeam)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| game | *StatusQuoBaseball.Gameplay.Game*<br>Game. |
| roadTeam | *StatusQuoBaseball.Base.Team*<br>Road team. |
| homeTeam | *StatusQuoBaseball.Base.Team*<br>Home team. |

### M:StatusQuoBaseball.Gameplay.Scoreboard.AddBottomOfInningNotPlayed

Adds the bottom of inning not played.


### M:StatusQuoBaseball.Gameplay.Scoreboard.AddInning

Adds the inning.


### M:StatusQuoBaseball.Gameplay.Scoreboard.AddInningError(fieldingTeam)

Adds the inning error.

| Name | Description |
| ---- | ----------- |
| fieldingTeam | *StatusQuoBaseball.Base.Team*<br>Fielding team. |

### M:StatusQuoBaseball.Gameplay.Scoreboard.AddInningHit(battingTeam)

Adds the inning hit.

| Name | Description |
| ---- | ----------- |
| battingTeam | *StatusQuoBaseball.Base.Team*<br>Batting team. |

### M:StatusQuoBaseball.Gameplay.Scoreboard.AddInningScore(scoringTeam)

Adds the inning score.

| Name | Description |
| ---- | ----------- |
| scoringTeam | *StatusQuoBaseball.Base.Team*<br>Scoring team. |

### P:StatusQuoBaseball.Gameplay.Scoreboard.CurrentInningIndex

Gets or sets the index of the current inning.


### P:StatusQuoBaseball.Gameplay.Scoreboard.Game

Gets or sets the game.


### M:StatusQuoBaseball.Gameplay.Scoreboard.GetTeamErrors(team)

Gets the team errors.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |

### M:StatusQuoBaseball.Gameplay.Scoreboard.GetTeamHits(team)

Gets the team hits.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |

### M:StatusQuoBaseball.Gameplay.Scoreboard.GetTeamRuns(team)

Gets the team runs.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |

### P:StatusQuoBaseball.Gameplay.Scoreboard.HomeTeam

Gets the home team.


### P:StatusQuoBaseball.Gameplay.Scoreboard.HomeTeamErrors

Gets the home team errors.


### P:StatusQuoBaseball.Gameplay.Scoreboard.HomeTeamHits

Gets the home team hits.


### P:StatusQuoBaseball.Gameplay.Scoreboard.HomeTeamScore

Gets the home team score.


### P:StatusQuoBaseball.Gameplay.Scoreboard.InningScores

Gets the inning scores.


### P:StatusQuoBaseball.Gameplay.Scoreboard.RoadTeam

Gets the road team.


### P:StatusQuoBaseball.Gameplay.Scoreboard.RoadTeamErrors

Gets the road team errors.


### P:StatusQuoBaseball.Gameplay.Scoreboard.RoadTeamHits

Gets the road team hits.


### P:StatusQuoBaseball.Gameplay.Scoreboard.RoadTeamScore

Gets the road team score.


### M:StatusQuoBaseball.Gameplay.Scoreboard.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Series

Series.


### M:StatusQuoBaseball.Gameplay.Series.#ctor(seriesName, roadTeam, homeTeam, numGames, playFullSeries, alternateVenues, silentMode, isSeasonMode, interval)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| seriesName | *System.String*<br>string |
| roadTeam | *StatusQuoBaseball.Base.Team*<br>Team |
| homeTeam | *StatusQuoBaseball.Base.Team*<br>Team |
| numGames | *System.Int32*<br>int |
| playFullSeries | *System.Boolean*<br>bool |
| alternateVenues | *System.Boolean*<br>bool |
| silentMode | *System.Boolean*<br>If set to true silent mode. |
| isSeasonMode | *System.Boolean*<br>If set to true is season mode. |
| interval | *System.Int32*<br>int |

### M:StatusQuoBaseball.Gameplay.Series.CheckSeriesOver(numWins)

Checks the series over.


#### Returns

true, if series over was checked, false otherwise.

| Name | Description |
| ---- | ----------- |
| numWins | *System.Int32*<br>int |

### P:StatusQuoBaseball.Gameplay.Series.CurrentHomeTeam

Gets the current home team.


### P:StatusQuoBaseball.Gameplay.Series.CurrentRoadTeam

Gets the current road team.


### M:StatusQuoBaseball.Gameplay.Series.Execute

Execute this instance.


### P:StatusQuoBaseball.Gameplay.Series.Games

Gets the games.


### P:StatusQuoBaseball.Gameplay.Series.HomeTeam

Team


### P:StatusQuoBaseball.Gameplay.Series.Interval

Gets or sets the interval.


### P:StatusQuoBaseball.Gameplay.Series.IsSeasonMode

Gets or sets a value indicating whether this is season mode.


### P:StatusQuoBaseball.Gameplay.Series.IsSeriesOver

Gets a value indicating whether this is series over.


### P:StatusQuoBaseball.Gameplay.Series.NumberOfHomeTeamHomeGames

Gets the number of home team home games.


### P:StatusQuoBaseball.Gameplay.Series.NumberOfRoadTeamHomeGames

Gets the number of road team home games.


### M:StatusQuoBaseball.Gameplay.Series.OnSeriesProgressHandled

Ons the series progress handled.


### P:StatusQuoBaseball.Gameplay.Series.RoadTeam

Gets the road team.


### P:StatusQuoBaseball.Gameplay.Series.SeriesLoser

Gets the series loser.


### P:StatusQuoBaseball.Gameplay.Series.SeriesName

Gets or sets the name of the series.


### E:StatusQuoBaseball.Gameplay.Series.SeriesProgressHandled

Occurs when series progress handled.


### P:StatusQuoBaseball.Gameplay.Series.SeriesWinner

Gets the series winner.


### M:StatusQuoBaseball.Gameplay.Series.ShowSeriesStatistics

Shows the series statistics.


### P:StatusQuoBaseball.Gameplay.Series.SilentMode

Gets or sets a value indicating whether this silent mode.


### M:StatusQuoBaseball.Gameplay.Series.StatusQuoBaseball#Gameplay#IProgressReporter#ReportProgress

Statuses the quo baseball. gameplay. IP rogress reporter. report progress.


### M:StatusQuoBaseball.Gameplay.Series.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Single

Single.


### M:StatusQuoBaseball.Gameplay.Single.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Single.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.Single.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.StealAttempt

Steal attempt.


### M:StatusQuoBaseball.Gameplay.StealAttempt.#ctor(pitcher, baserunner, catcher, initialBase, destinationBase, autoSuccessful)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| pitcher | *StatusQuoBaseball.Base.Player*<br>Player |
| baserunner | *StatusQuoBaseball.Base.Player*<br>Player |
| catcher | *StatusQuoBaseball.Base.Player*<br>Player |
| initialBase | *StatusQuoBaseball.Gameplay.Base*<br>Base |
| destinationBase | *StatusQuoBaseball.Gameplay.Base*<br>Base |
| autoSuccessful | *System.Boolean*<br>bool |

### M:StatusQuoBaseball.Gameplay.StealAttempt.AttemptStolenBase

Attempts the stolen base.


### P:StatusQuoBaseball.Gameplay.StealAttempt.AutoSuccessful

Gets a value indicating whether this auto successful.


### P:StatusQuoBaseball.Gameplay.StealAttempt.Baserunner

Gets the baserunner.


### P:StatusQuoBaseball.Gameplay.StealAttempt.Catcher

Gets the catcher.


### P:StatusQuoBaseball.Gameplay.StealAttempt.DestinationBase

Gets or sets the destination base.


### M:StatusQuoBaseball.Gameplay.StealAttempt.Execute

Execute the stolen base attempt.


### P:StatusQuoBaseball.Gameplay.StealAttempt.InitialBase

Gets or sets the initial base.


### M:StatusQuoBaseball.Gameplay.StealAttempt.OnStealAttempt(stealAttempt)

On the steal attempt.

| Name | Description |
| ---- | ----------- |
| stealAttempt | *StatusQuoBaseball.Gameplay.StealAttempt*<br>StealAttempt |

### E:StatusQuoBaseball.Gameplay.StealAttempt.StealAttemptHandled

Occurs when steal attempt handled.


### M:StatusQuoBaseball.Gameplay.StealAttempt.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


### P:StatusQuoBaseball.Gameplay.StealAttempt.WasSuccessful

Gets a value indicating whether this was successful.


## T:StatusQuoBaseball.Gameplay.StealAttemptEventArgs

Steal attempt event arguments.


### M:StatusQuoBaseball.Gameplay.StealAttemptEventArgs.#ctor(attempt)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| attempt | *StatusQuoBaseball.Gameplay.StealAttempt*<br>StealAttempt |

### P:StatusQuoBaseball.Gameplay.StealAttemptEventArgs.Attempt

Gets the attempt.


## T:StatusQuoBaseball.Gameplay.StealAttemptEventHandler

Inning action event handler.


## T:StatusQuoBaseball.Gameplay.Strikeout

Strikeout.


### M:StatusQuoBaseball.Gameplay.Strikeout.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Controlling player. |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Non controlling player. |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Strikeout.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.Strikeout.GetStrikeoutType

Gets the type of the strikeout.


#### Returns

StrikeoutType


### P:StatusQuoBaseball.Gameplay.Strikeout.StrikeoutType

Gets the type of the strikeout.


### M:StatusQuoBaseball.Gameplay.Strikeout.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.StrikeoutType

Strikeout type.


### F:StatusQuoBaseball.Gameplay.StrikeoutType.FoulTip

The foul tip.


### F:StatusQuoBaseball.Gameplay.StrikeoutType.Looking

The looking.


### F:StatusQuoBaseball.Gameplay.StrikeoutType.Swinging

The swinging.


### F:StatusQuoBaseball.Gameplay.StrikeoutType.Unknown

The unknown.


## T:StatusQuoBaseball.Gameplay.Triple

Triple.


### M:StatusQuoBaseball.Gameplay.Triple.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Triple.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.Triple.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Gameplay.Walk

Walk.


### M:StatusQuoBaseball.Gameplay.Walk.#ctor(controllingPlayer, nonControllingPlayer, batter)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| controllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| nonControllingPlayer | *StatusQuoBaseball.Base.Player*<br>Player |
| batter | *StatusQuoBaseball.Base.Player*<br>Player |

### M:StatusQuoBaseball.Gameplay.Walk.Execute

Execute this instance.


### M:StatusQuoBaseball.Gameplay.Walk.ToString

Returns a that represents the current .


#### Returns

A that represents the current .


## T:StatusQuoBaseball.Loaders.DatabaseCoachingAwardsLoader

Database coaching awards loader.


### M:StatusQuoBaseball.Loaders.DatabaseCoachingAwardsLoader.#ctor(database, sql)

Helper class to load a coach/manager from a database.

| Name | Description |
| ---- | ----------- |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.DatabaseCoachingAwardsLoader.Load

Load this instance.


#### Remarks

Returns a string array of awards (if any)


#### Returns

object


## T:StatusQuoBaseball.Loaders.DatabaseCoachLoader

Coach loader.


### M:StatusQuoBaseball.Loaders.DatabaseCoachLoader.#ctor(teamName, year, database, sql)

Helper class to load a coach/manager from a database.

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.DatabaseCoachLoader.Load

Load a coach from a database


#### Returns

object


## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseBattingStatsLoader

Database batting stats loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseBattingStatsLoader.#ctor(database, sql, dataTable)

Initializes a new instance of the class. NOTE: DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.


#### Remarks

 DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.

| Name | Description |
| ---- | ----------- |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |
| dataTable | *System.Data.DataTable*<br>DataTable |

### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseBattingStatsLoader.Load

Returns an array BattingStats as an object.


#### Returns

object


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseBattingStatsLoader.LoadStatsFromDatabase(dataTable)

Loads batting stats from database.


#### Returns

GameStats[]

| Name | Description |
| ---- | ----------- |
| dataTable | *System.Data.DataTable*<br>DataTable |

## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseChampionshipSeriesLoader

Database world series loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseChampionshipSeriesLoader.GetSeriesInfo(year, database)

Gets the series info.


#### Returns

SQLQueryResult

| Name | Description |
| ---- | ----------- |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseChampionshipSeriesLoader.GetSeriesTeams(year, round, database)

Gets the series teams.


#### Returns

Tuple(string,string)

| Name | Description |
| ---- | ----------- |
| year | *System.Int32*<br>int |
| round | *System.String*<br>string |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseFieldingStatsLoader

Database FieldingStats stats loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseFieldingStatsLoader.#ctor(database, sql, dataTable)

Initializes a new instance of the class. NOTE: DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.


#### Remarks

 DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.

| Name | Description |
| ---- | ----------- |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |
| dataTable | *System.Data.DataTable*<br>DataTable |

### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseFieldingStatsLoader.Load

Returns FieldingStats[] arrau as an object.


#### Returns

object


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseFieldingStatsLoader.LoadStatsFromDatabase(dataTable)

Loads FieldingStats[] array from database.


#### Returns

GameStats[]

| Name | Description |
| ---- | ----------- |
| dataTable | *System.Data.DataTable*<br>DataTable |

## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGameStatsLoader

Database game stats loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGameStatsLoader.#ctor(database, sql, dataTable)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |
| dataTable | *System.Data.DataTable*<br>DataTable |

### F:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGameStatsLoader.dataTable

The data table.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGameStatsLoader.LoadStatsFromDatabase(dataTable)

Loads the stats from database.


#### Returns

GameStats

| Name | Description |
| ---- | ----------- |
| dataTable | *System.Data.DataTable*<br>DataTable |

### F:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGameStatsLoader.stats

The game stats.


## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGroupLoader

Database team group loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseGroupLoader.LoadRoot(leagueName, year, database, seriesLength)

Loads the team group.


#### Returns

TeamGroup

| Name | Description |
| ---- | ----------- |
| leagueName | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| seriesLength | *System.Int32*<br>int |

## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader

Database loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader.#ctor(database, sql)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |

### F:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader.database

The database.


### P:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader.Database

Gets the database.


### F:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader.sql

The sql.


### P:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseLoader.Sql

Gets the sql query text.


## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabasePitchingStatsLoader

Database batting stats loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabasePitchingStatsLoader.#ctor(database, sql, dataTable)

Initializes a new instance of the class. NOTE: DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.


#### Remarks

 DO NOT pass in Db and string arguments. Set Db to NULL and sql to String.Empty.

| Name | Description |
| ---- | ----------- |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |
| dataTable | *System.Data.DataTable*<br>DataTable |

### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabasePitchingStatsLoader.Load

Returns PitchingStats[] array as an object.


#### Returns

object


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabasePitchingStatsLoader.LoadStatsFromDatabase(dataTable)

Loads PitchingStats[] array from database.


#### Returns

GameStats[]

| Name | Description |
| ---- | ----------- |
| dataTable | *System.Data.DataTable*<br>DataTable |

## T:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseRosterLoader

Database roster loader.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseRosterLoader.#ctor(teamName, year, database, sql)

Helper class to load a roster from a database.

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |

### P:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseRosterLoader.DataTables

Gets the data tables.


### M:StatusQuoBaseball.Loaders.DatabaseLoaders.DatabaseRosterLoader.Load

Loads a roster of (Player[] objects from a database.


#### Returns

object


## T:StatusQuoBaseball.Loaders.DatabasePersonLoader

Helper clas to get player and manager information from files or a database.


### M:StatusQuoBaseball.Loaders.DatabasePersonLoader.#ctor(teamName, year, database, sql)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |

### F:StatusQuoBaseball.Loaders.DatabasePersonLoader.dataRows

The data rows.


### M:StatusQuoBaseball.Loaders.DatabasePersonLoader.Load

Returns a PersonBasicInformation array. This can be used to initialize a coach or a list of players.


#### Returns

object


### F:StatusQuoBaseball.Loaders.DatabasePersonLoader.teamName

The name of the team.


### P:StatusQuoBaseball.Loaders.DatabasePersonLoader.TeamName

Gets the name of the team.


### F:StatusQuoBaseball.Loaders.DatabasePersonLoader.year

The year of the team.


### P:StatusQuoBaseball.Loaders.DatabasePersonLoader.Year

Gets the year.


## T:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader

Helper clas to get player and manager information from files or a database.


### M:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader.#ctor(teamName, year, database, sql, storedProceduresToRun)

Loads categories of player statistics (batting, pitching, fielding)

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |
| sql | *System.String*<br>string |
| storedProceduresToRun | *StatusQuoBaseball.Database.SQLStoredProcedure[]*<br>SQLStoredProcedure[] |

### F:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader.dataTables

The data tables.


### M:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader.Load

Returns a Dictionary(string,DataTable>)of lists with batting, pitching, and fielding information. This can be used to initialize a coach or a list of players.


#### Returns

object


### F:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader.teamName

The name of the team.


### P:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader.TeamName

Gets the name of the team.


### F:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader.year

The year.


### P:StatusQuoBaseball.Loaders.DatabasePlayerStatisticsLoader.Year

Gets the year.


## T:StatusQuoBaseball.Loaders.DatabaseTeamLoader

Team loader.


### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.GetMultipleKeys(searchTerm, year, database)

Gets the multiple keys.


#### Returns

The multiple keys.

| Name | Description |
| ---- | ----------- |
| searchTerm | *System.String*<br>Search term. |
| year | *System.Int32*<br>Year. |
| database | *StatusQuoBaseball.Database.Db*<br>Database. |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadCoachFromDatabase(teamName, year, database)

Loads the coach from database.


#### Returns

Coach

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadRosterFromDatabase(team, teamKey, year, database)

Loads the roster from database.


#### Returns

Roster

| Name | Description |
| ---- | ----------- |
| team | *StatusQuoBaseball.Base.Team*<br>Team |
| teamKey | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadTeam(teamName, year, database)

Loads the team.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadTeam(teamName, mascot, year, database)

Loads the team.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| mascot | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadTeam(teamName, mascot, teamKey, year, database)

Loads the team.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| mascot | *System.String*<br>string |
| teamKey | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadTeamByKey(teamKey, year, database)

Loads the team.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| teamKey | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadTeamFromFranchiseID(franchID, year, database)

Loads the team from franchise identifier.


#### Returns

The team from franchise identifier.

| Name | Description |
| ---- | ----------- |
| franchID | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

### M:StatusQuoBaseball.Loaders.DatabaseTeamLoader.LoadTeamFromTeamID(searchTerm, year, database)

Loads the team.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| searchTerm | *System.String*<br>string |
| year | *System.Int32*<br>int |
| database | *StatusQuoBaseball.Database.Db*<br>Db |

## T:StatusQuoBaseball.Loaders.FileObjectLoader

Helper class to load objects from files. Implements ILoadable.


### M:StatusQuoBaseball.Loaders.FileObjectLoader.#ctor(fileName)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| fileName | *System.String*<br>string |

### F:StatusQuoBaseball.Loaders.FileObjectLoader.fileName

The name of the file.


### P:StatusQuoBaseball.Loaders.FileObjectLoader.FileName

Gets the name of the file.


## T:StatusQuoBaseball.Loaders.ILoadable

Represents an interface for any object that can be loaded from a file or database.


### M:StatusQuoBaseball.Loaders.ILoadable.Load

Load this instance.


#### Returns

object


## T:StatusQuoBaseball.Loaders.ObjectLoader

Helper class to load an object from a file or database.


### M:StatusQuoBaseball.Loaders.ObjectLoader.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Loaders.ObjectLoader.Load

Load this instance.


#### Returns

object


## T:StatusQuoBaseball.Loaders.PersonBasicInformation

Pass person basic info (shared by coaches and players) because the tuple only takes 8 arguments.


### M:StatusQuoBaseball.Loaders.PersonBasicInformation.#ctor(id, lName, fName, number, naturalPosition, race, handedness, bats, height, weight, birthday, deathday)

Initializes a new instance of the struct.

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>Identifier. |
| lName | *System.String*<br>L name. |
| fName | *System.String*<br>F name. |
| number | *System.String*<br>Number. |
| naturalPosition | *System.String*<br>Natural position. |
| race | *StatusQuoBaseball.Base.Race*<br>Race. |
| handedness | *StatusQuoBaseball.Base.Handedness*<br>Handedness. |
| bats | *StatusQuoBaseball.Base.Handedness*<br>Bats. |
| height | *StatusQuoBaseball.Base.Height*<br>Height. |
| weight | *StatusQuoBaseball.Base.Weight*<br>Weight. |
| birthday | *StatusQuoBaseball.Base.Birthday*<br>Birthday |
| deathday | *StatusQuoBaseball.Base.Deathday*<br>Deathday |

### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Bats

Gets the bats.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Birthday

Gets the birthday.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Deathday

Gets the deathday.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.FName

Gets the FN ame.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Handedness

Gets the handedness.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Height

Gets the height.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Id

Gets the identifier.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.LName

Gets the LN ame.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.NaturalPosition

Gets the natural position.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Number

Gets the number.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Race

Gets the race.


### P:StatusQuoBaseball.Loaders.PersonBasicInformation.Weight

Gets the weight.


## T:StatusQuoBaseball.Loaders.TeamLoader

Team loader.


### M:StatusQuoBaseball.Loaders.TeamLoader.GetFullTeamNameFromDirectory(directory)

Gets the full team name from directory.


#### Returns

The full team name from directory.

| Name | Description |
| ---- | ----------- |
| directory | *System.String*<br>Directory. |

### M:StatusQuoBaseball.Loaders.TeamLoader.GetTeamNameFromDirectory(directory)

Gets the team name from directory.


#### Returns

string[]

| Name | Description |
| ---- | ----------- |
| directory | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadBattingStats(roster, directory)

Loads the batting stats.

| Name | Description |
| ---- | ----------- |
| roster | *StatusQuoBaseball.Base.Player[]@*<br>Player[] |
| directory | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadCoachFromFile(directory)

Loads the coach from file.


#### Returns

Coach

| Name | Description |
| ---- | ----------- |
| directory | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadFieldingStats(roster, directory)

Loads the fielding stats.

| Name | Description |
| ---- | ----------- |
| roster | *StatusQuoBaseball.Base.Player[]@*<br>Player[] |
| directory | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadPitchingStats(roster, directory)

Loads the pitching stats.

| Name | Description |
| ---- | ----------- |
| roster | *StatusQuoBaseball.Base.Player[]@*<br>Player[] |
| directory | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadTeam(directory)

Loads the roster of players from a file.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| directory | *System.String*<br>string |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadTeamFromFile(System.Collections.Generic.Dictionary{System.Int32,System.Collections.Generic.Dictionary{System.String,System.Object}})

Loads the team from file.


#### Returns

The team from file.

| Name | Description |
| ---- | ----------- |
| data | *Unknown type*<br>Dictionary |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadTeamFromFile(directory)

Loads the team from file.


#### Returns

The team from file.

| Name | Description |
| ---- | ----------- |
| directory | *System.String*<br>Directory. |

### M:StatusQuoBaseball.Loaders.TeamLoader.LoadUniforms(roster, directory)

Loads the uniforms.

| Name | Description |
| ---- | ----------- |
| roster | *StatusQuoBaseball.Base.Player[]@*<br>Roster. |
| directory | *System.String*<br>Directory. |

## T:StatusQuoBaseball.MainClass

Main class.


### F:StatusQuoBaseball.MainClass.conn

The conn.


### M:StatusQuoBaseball.MainClass.Main(args)

The entry point of the program, where the program control starts and ends.

| Name | Description |
| ---- | ----------- |
| args | *System.String[]*<br>string[] |

## T:StatusQuoBaseball.Menu.CleanGamesFolder

Clean games folder.


### M:StatusQuoBaseball.Menu.CleanGamesFolder.LoadCleanGamesFolder(Bullock.TextMenu.Runnable)

Loads the clean games folder.


## T:StatusQuoBaseball.Menu.Menu

Menu.


### M:StatusQuoBaseball.Menu.Menu.#ctor

Initializes a new instance of the class.


## T:StatusQuoBaseball.Menu.PlayChampionshipSeries

Play world series.


### M:StatusQuoBaseball.Menu.PlayChampionshipSeries.GetTeamKeysByRound(round, result)

Gets the team keys by round.


#### Returns

Tuple(string,string)

| Name | Description |
| ---- | ----------- |
| round | *System.String*<br>string |
| result | *StatusQuoBaseball.Database.SQLQueryResult*<br>SQLQueryResult |

### M:StatusQuoBaseball.Menu.PlayChampionshipSeries.LoadChampionshipSeries(mainMenu)

Loads the view team inforamtion.

| Name | Description |
| ---- | ----------- |
| mainMenu | *Bullock.TextMenu.ConsoleMenu*<br>ConsoleMenu |

### M:StatusQuoBaseball.Menu.PlayChampionshipSeries.SelectWorldSeries(r)

Selects the world series based on the year provided.

| Name | Description |
| ---- | ----------- |
| r | *Bullock.TextMenu.Runnable*<br>Runnable |

## T:StatusQuoBaseball.Menu.PlaySeries

Play world series.


### M:StatusQuoBaseball.Menu.PlaySeries.ChooseTeam(msg)

Chooses the team.


#### Returns

Team

| Name | Description |
| ---- | ----------- |
| msg | *System.String*<br>string |

### M:StatusQuoBaseball.Menu.PlaySeries.LoadPlaySeries(mainMenu)

Loads the view team inforamtion.

| Name | Description |
| ---- | ----------- |
| mainMenu | *Bullock.TextMenu.ConsoleMenu*<br>ConsoleMenu |

### M:StatusQuoBaseball.Menu.PlaySeries.LoadTeam(teamName, mascot, year, showExtendedToString, capitalizeNames)

Loads the team.

| Name | Description |
| ---- | ----------- |
| teamName | *System.String*<br>string |
| mascot | *System.String*<br>string |
| year | *System.Int32*<br>int |
| showExtendedToString | *System.Boolean*<br>bool |
| capitalizeNames | *System.Boolean*<br>If set to true capitalize names. |

### M:StatusQuoBaseball.Menu.PlaySeries.PlayTheSeries(seriesName, roadTeam, homeTeam, numGames, playFullSeries, silentMode)

Plays a series (e.g, World Series)

| Name | Description |
| ---- | ----------- |
| seriesName | *System.String*<br>string |
| roadTeam | *StatusQuoBaseball.Base.Team*<br>Team |
| homeTeam | *StatusQuoBaseball.Base.Team*<br>Team |
| numGames | *System.Int32*<br>int |
| playFullSeries | *System.Boolean*<br>bool |
| silentMode | *System.Boolean*<br>bool |

### M:StatusQuoBaseball.Menu.PlaySeries.SetUpSeries(r)

Selects the world series based on the year provided.

| Name | Description |
| ---- | ----------- |
| r | *Bullock.TextMenu.Runnable*<br>Runnable |

## T:StatusQuoBaseball.Menu.ProgramExit

Program exit.


### M:StatusQuoBaseball.Menu.ProgramExit.Exit(r)



| Name | Description |
| ---- | ----------- |
| r | *Bullock.TextMenu.Runnable*<br>Runnable |

## T:StatusQuoBaseball.Menu.ViewLeagueInformation

View team information.


### M:StatusQuoBaseball.Menu.ViewLeagueInformation.Display(r)

Display the specified r.

| Name | Description |
| ---- | ----------- |
| r | *Bullock.TextMenu.Runnable*<br>Runnable |

### M:StatusQuoBaseball.Menu.ViewLeagueInformation.DisplayLevel(level, text)

Displays the level of the league tree.

| Name | Description |
| ---- | ----------- |
| level | *System.Int32*<br>int |
| text | *System.String*<br>Text. |

### M:StatusQuoBaseball.Menu.ViewLeagueInformation.LoadViewLeagueInforamtion(mainMenu)

Loads the view league inforamtion.

| Name | Description |
| ---- | ----------- |
| mainMenu | *Bullock.TextMenu.ConsoleMenu*<br>ConsoleMenu |

## T:StatusQuoBaseball.Menu.ViewTeamInformation

View team information.


### M:StatusQuoBaseball.Menu.ViewTeamInformation.ChooseTeam(r)

Chooses the team.

| Name | Description |
| ---- | ----------- |
| r | *Bullock.TextMenu.Runnable*<br>Runnable |

### M:StatusQuoBaseball.Menu.ViewTeamInformation.Display(r)

Display the specified r.

| Name | Description |
| ---- | ----------- |
| r | *Bullock.TextMenu.Runnable*<br>Runnable |

### M:StatusQuoBaseball.Menu.ViewTeamInformation.LoadTeam(searchTerm, secondPass, capitalizeNames)

Loads the team.

| Name | Description |
| ---- | ----------- |
| searchTerm | *System.String*<br>string |
| secondPass | *System.Boolean*<br>bool |
| capitalizeNames | *System.Boolean*<br>If set to true capitalize names. |

### M:StatusQuoBaseball.Menu.ViewTeamInformation.LoadViewTeamInforamtion(mainMenu)

Loads the view team inforamtion.

| Name | Description |
| ---- | ----------- |
| mainMenu | *Bullock.TextMenu.ConsoleMenu*<br>ConsoleMenu |

## T:StatusQuoBaseball.Tests.NArrayUtilities

NArrayUtilities.


### M:StatusQuoBaseball.Tests.NArrayUtilities.TestArrayContains

Tests the array contains.


## T:StatusQuoBaseball.Tests.NBattingStats

NB atting stats.


### M:StatusQuoBaseball.Tests.NBattingStats.TestBattingResultsArrayLength

Tests the length of the batting results array.


### M:StatusQuoBaseball.Tests.NBattingStats.TestBattingResultsOutcomes

Tests the batting results outcomes.


### M:StatusQuoBaseball.Tests.NBattingStats.TestLoadBattingStatsFromFile

Tests the load batting stats from file.


### M:StatusQuoBaseball.Tests.NBattingStats.TestPowerRating

Tests the power rating.


## T:StatusQuoBaseball.Tests.NBirthday

NBirthday.


### M:StatusQuoBaseball.Tests.NBirthday.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NBirthday.TestEmptyBirthdayGetAge

Tests the empty birthday get age.


### M:StatusQuoBaseball.Tests.NBirthday.TestGetAge

Tests the get age.


### M:StatusQuoBaseball.Tests.NBirthday.TestGetAgeDateTimeConstructor

Tests the get age date time constructor.


### M:StatusQuoBaseball.Tests.NBirthday.TestGetAgeStringConstructor

Tests the get age string constructor.


## T:StatusQuoBaseball.Tests.NChampionshipSeries

NArrayUtilities.


### M:StatusQuoBaseball.Tests.NChampionshipSeries.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NChampionshipSeries.TestYears

Tests the array contains.


## T:StatusQuoBaseball.Tests.NCheckInningsPitched

NCheck innings pitched.


### M:StatusQuoBaseball.Tests.NCheckInningsPitched.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NCheckInningsPitched.TestCheckInningsPitched

NCs the heck innings pitched.


## T:StatusQuoBaseball.Tests.NCoach

NCoach.


### M:StatusQuoBaseball.Tests.NCoach.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NCoach.TestGetCoachInfo

Tests the get coach info.


### M:StatusQuoBaseball.Tests.NCoach.TestLoadCoachFromFile

Tests the load coach from file.


## T:StatusQuoBaseball.Tests.NConfigurationManger

NConfigurationManger.


### M:StatusQuoBaseball.Tests.NConfigurationManger.TestGetConfigFileInformation

Tests the get config file information.


### M:StatusQuoBaseball.Tests.NConfigurationManger.TestGetMultipleConfigFileInformation

Tests the get multiple config file information.


### M:StatusQuoBaseball.Tests.NConfigurationManger.TestIncorrectConfigFileInformation

Tests the incorrect config file information.


## T:StatusQuoBaseball.Tests.NDatabase

NDatabase.


### M:StatusQuoBaseball.Tests.NDatabase.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NDatabase.TestDatabaseConnection

Tests the database connection.


### M:StatusQuoBaseball.Tests.NDatabase.TestSelectBatters

Tests the select batters.


### M:StatusQuoBaseball.Tests.NDatabase.TestSelectPitchers

Tests the select pitchers.


### M:StatusQuoBaseball.Tests.NDatabase.TestStoredProcedureMultipleQueries

Tests the stored procedure multiple queries.


### M:StatusQuoBaseball.Tests.NDatabase.TestStoredProcedureParameterExceptionThrown

Tests the stored procedure parameter exception thrown.


### M:StatusQuoBaseball.Tests.NDatabase.TestStoredProcedureTextTwoParameters

Tests the stored procedure text two parameters.


## T:StatusQuoBaseball.Tests.NDiceRoll

NDiceRoll.


### M:StatusQuoBaseball.Tests.NDiceRoll.Test2d10DiceRoll

Test2d10s the dice roll.


### M:StatusQuoBaseball.Tests.NDiceRoll.TestMultipleDiceRoll

Tests the multiple dice roll.


### M:StatusQuoBaseball.Tests.NDiceRoll.TestSingleDiceRoll

Tests the single dice roll.


## T:StatusQuoBaseball.Tests.NFieldingStatistics

NFieldingStatistics.


### M:StatusQuoBaseball.Tests.NFieldingStatistics.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NFieldingStatistics.TestFieldingStatistics

Tests the fielding statistics.


## T:StatusQuoBaseball.Tests.NFieldingStats

NFielding stats.


### M:StatusQuoBaseball.Tests.NFieldingStats.TestLoadFieldingStatsFromFile

Tests the load fielding stats from file.


## T:StatusQuoBaseball.Tests.NFraction

NFraction.


### M:StatusQuoBaseball.Tests.NFraction.TestFractionReduction

Tests the fraction reduction.


## T:StatusQuoBaseball.Tests.NHeight

NHeight.


### M:StatusQuoBaseball.Tests.NHeight.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NHeight.TestEmptyHeight

Tests the empty height.


### M:StatusQuoBaseball.Tests.NHeight.TestEmptyHeightReferenceEquality

Tests the empty height reference equality.


### M:StatusQuoBaseball.Tests.NHeight.TestGetHeightAverage

Tests the get height average.


### M:StatusQuoBaseball.Tests.NHeight.TestGetHeightFromStringConstructor

Tests the get height from string constructor.


### M:StatusQuoBaseball.Tests.NHeight.TestGetHeightInFeet

Tests the get height in feet.


### M:StatusQuoBaseball.Tests.NHeight.TestGetHeightInMeters

Tests the get height in meters.


## T:StatusQuoBaseball.Tests.NInMemoryConfigurationFile

NInMemoryConfigurationFile.


### M:StatusQuoBaseball.Tests.NInMemoryConfigurationFile.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NInMemoryConfigurationFile.TestInMemoryConfigurationFile

Tests the in memory configuration file.


## T:StatusQuoBaseball.Tests.NInMemoryCSVFile

NInMemoryCSVFile.


### M:StatusQuoBaseball.Tests.NInMemoryCSVFile.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NInMemoryCSVFile.TestCSVFileLoad

Tests the CSVF ile load.


## T:StatusQuoBaseball.Tests.NInning

NI nning.


### M:StatusQuoBaseball.Tests.NInning.TestInningNames

Tests the inning names.


## T:StatusQuoBaseball.Tests.NLoaders

NLoaders.


### M:StatusQuoBaseball.Tests.NLoaders.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseCoachLoaderDiamondbacks2001

Tests the database coach loader diamondbacks2001.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseCoachLoaderMarlins2001

Tests the database coach loader marlins2001.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseCoachLoaderYankees2001

Tests the database coach loader yankees2001.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseDivisionLoaderFullAL1980

Tests the database division loader full AL 1980.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseDivisionLoaderFullAL2001

Tests the database division loader full AL 2001.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseDivisionLoaderFullMLB1980

Tests the database division loader full MLB 1980.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseDivisionLoaderFullNL1980

Tests the database division loader full NL 1980.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseDivisionLoaderFullNL2001

Tests the database division loader full NL 2001.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseDivisionLoaderParts

Tests the database division loader parts.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseLoaderEx

Tests the database loader ex.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabasePlayerStatisticsLoader

Tests the database player statistics loader.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseRosterLoader

Tests the database roster loader.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseTeamLoader

Tests the database team loader.


### M:StatusQuoBaseball.Tests.NLoaders.TestDatabaseTeamLoaderMets2001

Tests the database team loader mets2001.


### M:StatusQuoBaseball.Tests.NLoaders.TestGetMultipleFranchiseKeys

Tests the get multiple franchise keys.


## T:StatusQuoBaseball.Tests.NLogger

NLogger.


### M:StatusQuoBaseball.Tests.NLogger.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NLogger.TestWriteToFile

Tests the write to file.


## T:StatusQuoBaseball.Tests.NMarkdownFromXml

NMarkdownFromXml.


### M:StatusQuoBaseball.Tests.NMarkdownFromXml.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NMarkdownFromXml.Test

Test this instance.


## T:StatusQuoBaseball.Tests.NNullPlayer

NNull player.


### M:StatusQuoBaseball.Tests.NNullPlayer.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NNullPlayer.TestNullPlayer

Tests the null player.


## T:StatusQuoBaseball.Tests.NOrdinalNumberGenerator

NOrdinalNumberGenerator.


### M:StatusQuoBaseball.Tests.NOrdinalNumberGenerator.TestOrdinalNumberGenerator

Tests the ordinal number generator.


## T:StatusQuoBaseball.Tests.NPitchingStats

NPitching stats.


### M:StatusQuoBaseball.Tests.NPitchingStats.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NPitchingStats.TestLoadPitchingStatsFromFile

Tests the load pitching stats from file.


### M:StatusQuoBaseball.Tests.NPitchingStats.TestPitcherGame

Tests the pitcher game.


### M:StatusQuoBaseball.Tests.NPitchingStats.TestPitchResultsArrayLength

Tests the length of the pitch results array.


### M:StatusQuoBaseball.Tests.NPitchingStats.TestPitchResultsOutcomes

Tests the pitch results outcomes.


## T:StatusQuoBaseball.Tests.NPlayer

NP layer.


### M:StatusQuoBaseball.Tests.NPlayer.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NPlayer.TestGetPlayerInfo

Tests the get player info.


## T:StatusQuoBaseball.Tests.NRankings

NRankings.


### M:StatusQuoBaseball.Tests.NRankings.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NRankings.TestRankBattingAverage

Tests the rank batting average.


### M:StatusQuoBaseball.Tests.NRankings.TestRankByHits

Tests the rank by hits.


### M:StatusQuoBaseball.Tests.NRankings.TestRankEarnedRunAverage

Tests the rank earned run average.


### M:StatusQuoBaseball.Tests.NRankings.TestRankEarnedRunAverageBottom

Tests the rank earned run average bottom 10 pitchers.


### M:StatusQuoBaseball.Tests.NRankings.TestRankStrikeouts

Tests the rank strikeouts.


## T:StatusQuoBaseball.Tests.NRoundRobin

NRoundRobin.


### M:StatusQuoBaseball.Tests.NRoundRobin.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NRoundRobin.ReportProgress(e)

Reports the progress of the round robin.

| Name | Description |
| ---- | ----------- |
| e | *StatusQuoBaseball.Gameplay.ProgressReporterEventArgs*<br>ProgressReporterEventArgs |

### M:StatusQuoBaseball.Tests.NRoundRobin.TestRoundRobinEven

Tests the round robin - even games


### M:StatusQuoBaseball.Tests.NRoundRobin.TestRoundRobinFullDivisions1969

Tests the round robin full divisions1969.


### M:StatusQuoBaseball.Tests.NRoundRobin.TestRoundRobinFullDivisions2019

Tests the round robin full divisions1980.


### M:StatusQuoBaseball.Tests.NRoundRobin.TestRoundRobinOdd

Tests the round robin.


## T:StatusQuoBaseball.Tests.NSABRMetricsManager

NArrayUtilities.


### M:StatusQuoBaseball.Tests.NSABRMetricsManager.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NSABRMetricsManager.TestGetFIP

Tests the get fip.


## T:StatusQuoBaseball.Tests.NSerializationMethods

NSerializationMethods.


### M:StatusQuoBaseball.Tests.NSerializationMethods.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NSerializationMethods.TestSerializeToFile

Tests the serialize to file.


## T:StatusQuoBaseball.Tests.NStrikeoutType

NStrikeoutType.


### M:StatusQuoBaseball.Tests.NStrikeoutType.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NStrikeoutType.TestPitcherStrikeoutType

Tests the type of the pitcher strikeout.


## T:StatusQuoBaseball.Tests.NTeam

NTeam.


### M:StatusQuoBaseball.Tests.NTeam.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NTeam.TestGetStartingPitcherVariety

Tests the get starting pitcher variety.


### M:StatusQuoBaseball.Tests.NTeam.TestGetTeamNameFromDirectory

Tests the get team name from directory.


### M:StatusQuoBaseball.Tests.NTeam.TestLoadFromFile

Tests the load from file.


### M:StatusQuoBaseball.Tests.NTeam.TestTeamDisplayer

Tests the team displayer.


## T:StatusQuoBaseball.Tests.NTestFlyouts

NTest flyouts.


### M:StatusQuoBaseball.Tests.NTestFlyouts.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NTestFlyouts.TestDeepFlyOutLocation

Tests the deep fly out location.


### M:StatusQuoBaseball.Tests.NTestFlyouts.TestFlyOutLocation

Tests the fly out location.


### M:StatusQuoBaseball.Tests.NTestFlyouts.TestPopFlyOutLocation

Tests the pop fly out location.


## T:StatusQuoBaseball.Tests.NTestGroundouts

NTest groundouts.


### M:StatusQuoBaseball.Tests.NTestGroundouts.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NTestGroundouts.TestGroundoutLocation

Tests the groundout location.


## T:StatusQuoBaseball.Tests.NTextUtilities

NTextUtilities.


### M:StatusQuoBaseball.Tests.NTextUtilities.TestCenterJustificationFiller

Tests the center justification filler.


### M:StatusQuoBaseball.Tests.NTextUtilities.TestLeftJustificationFiller

Tests the left justification filler.


### M:StatusQuoBaseball.Tests.NTextUtilities.TestRightJustificationFiller

Tests the right justification filler.


## T:StatusQuoBaseball.Tests.NUniform

NUniform.


### M:StatusQuoBaseball.Tests.NUniform.TestLoadArizonaUniformsFromFile

Tests the load arizona uniforms from file.


### M:StatusQuoBaseball.Tests.NUniform.TestLoadNewYorkUniformsFromFile

Tests the load new york uniforms from file.


### M:StatusQuoBaseball.Tests.NUniform.TestLoadSeattleUniformsFromFile

Tests the load seattle uniforms from file.


## T:StatusQuoBaseball.Tests.NVenue

NV enue.


### M:StatusQuoBaseball.Tests.NVenue.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NVenue.TestGenericVenueInformation

Tests the generic venue information.


### M:StatusQuoBaseball.Tests.NVenue.TestGetVenueInformation

Tests the get venue information.


### M:StatusQuoBaseball.Tests.NVenue.TestGetVenueManager

Tests the get venue manager.


## T:StatusQuoBaseball.Tests.NWeight

NWeight.


### M:StatusQuoBaseball.Tests.NWeight.Init

Init this instance.


### M:StatusQuoBaseball.Tests.NWeight.TestEmptyWeight

Tests the empty weight.


### M:StatusQuoBaseball.Tests.NWeight.TestEmptyWeightReferenceEquality

Tests the empty weight reference equality.


### M:StatusQuoBaseball.Tests.NWeight.TestGetWeightAverageKilograms

Tests the get weight average kilograms.


### M:StatusQuoBaseball.Tests.NWeight.TestGetWeightAveragePounds

Tests the get weight average pounds.


### M:StatusQuoBaseball.Tests.NWeight.TestWeightToKiloString

Tests the weight to kilo string.


### M:StatusQuoBaseball.Tests.NWeight.TestWeightToString

Tests the weight to string.


## T:StatusQuoBaseball.Utilities.ArrayUtilities`1

Array utilities.


### M:StatusQuoBaseball.Utilities.ArrayUtilities`1.ArrayContains(search, array)

Checks if an array contains T item.


#### Returns

true, if contains was arrayed, false otherwise.

| Name | Description |
| ---- | ----------- |
| search | *`0*<br>T |
| array | *`0[]*<br>T |

## T:StatusQuoBaseball.Utilities.Constants

Constants.


### F:StatusQuoBaseball.Utilities.Constants.CONFIG_FILE_COMMENT_CHAR

The config file comment char.


### F:StatusQuoBaseball.Utilities.Constants.CONFIG_FILE_DELIMITER

The config file delimiter.


### F:StatusQuoBaseball.Utilities.Constants.CONFIG_FILE_PATH

The config file path.


### M:StatusQuoBaseball.Utilities.Constants.GetValueFromDouble(val1, val2)

Gets the value from double.


#### Returns

The value from double.

| Name | Description |
| ---- | ----------- |
| val1 | *System.Double*<br>double |
| val2 | *System.Double*<br>double |

### F:StatusQuoBaseball.Utilities.Constants.MONTHS

The months.


### M:StatusQuoBaseball.Utilities.Constants.RoundDown(number, decimalPlaces)

Rounds down.


#### Returns

double

| Name | Description |
| ---- | ----------- |
| number | *System.Double*<br>double |
| decimalPlaces | *System.Int32*<br>int |

### M:StatusQuoBaseball.Utilities.Constants.ScaleRange(value)

Scales the range to base 10.


#### Returns

The range.

| Name | Description |
| ---- | ----------- |
| value | *System.Double*<br>Value. |

### F:StatusQuoBaseball.Utilities.Constants.SQLITE3_CONNECTION_STRING

The SQLITE 3 connection string.


## T:StatusQuoBaseball.Utilities.Dice

Dice class.


### M:StatusQuoBaseball.Utilities.Dice.#cctor

Initializes the class.


### M:StatusQuoBaseball.Utilities.Dice.Roll(min, max, dice)

Roll the dice, N times.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| min | *System.Int32*<br>int |
| max | *System.Int32*<br>int |
| dice | *System.Int32*<br>int |

### M:StatusQuoBaseball.Utilities.Dice.Roll2d10

Roll2d10 this instance.


#### Returns

The roll2d10.


## T:StatusQuoBaseball.Utilities.Dumper

Dumper.


### M:StatusQuoBaseball.Utilities.Dumper.Dump(obj)

Dump the specified object to console.

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>object |

## T:StatusQuoBaseball.Utilities.ExtendedConsole

Extended console.


### M:StatusQuoBaseball.Utilities.ExtendedConsole.PrintIEnumerable``1(list)

Prints the IE numerable.

| Name | Description |
| ---- | ----------- |
| list | *System.Collections.Generic.IEnumerable{``0}*<br>IEnumerable |


### M:StatusQuoBaseball.Utilities.ExtendedConsole.PrintType``1(item)

Prints the type.

| Name | Description |
| ---- | ----------- |
| item | *``0*<br>T |


## T:StatusQuoBaseball.Utilities.ExtendedPropertyMethods

Extended property methods.


### M:StatusQuoBaseball.Utilities.ExtendedPropertyMethods.GetPropValue(obj, name)

Gets the property value.


#### Returns

The property value.

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>object |
| name | *System.String*<br>string |

### M:StatusQuoBaseball.Utilities.ExtendedPropertyMethods.GetPropValue``1(obj, name)

Gets the property value of the provided property.


#### Returns

The property value.

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>object |
| name | *System.String*<br>string |


## T:StatusQuoBaseball.Utilities.ExtensionClassMethods

Extension class methods.


### M:StatusQuoBaseball.Utilities.ExtensionClassMethods.ForEach``2(System.Collections.Generic.Dictionary{``0,``1},System.Action{``0,``1})

ForEach extension method for Dictionary,

| Name | Description |
| ---- | ----------- |
| dictionary | *Unknown type*<br>Dictionary. |
| invoke | *Unknown type*<br>Invoke. |


## T:StatusQuoBaseball.Utilities.Fraction

Fraction.


### M:StatusQuoBaseball.Utilities.Fraction.#ctor

Constructors


### M:StatusQuoBaseball.Utilities.Fraction.#ctor(dDecimalValue)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| dDecimalValue | *System.Double*<br>D decimal value. |

### M:StatusQuoBaseball.Utilities.Fraction.#ctor(iWholeNumber)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| iWholeNumber | *System.Int64*<br>I whole number. |

### M:StatusQuoBaseball.Utilities.Fraction.#ctor(iNumerator, iDenominator)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| iNumerator | *System.Int64*<br>I numerator. |
| iDenominator | *System.Int64*<br>I denominator. |

### M:StatusQuoBaseball.Utilities.Fraction.#ctor(strValue)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| strValue | *System.String*<br>String value. |

### M:StatusQuoBaseball.Utilities.Fraction.Add(StatusQuoBaseball.Utilities.Fraction,StatusQuoBaseball.Utilities.Fraction)

internal functions for binary operations


### P:StatusQuoBaseball.Utilities.Fraction.Denominator

Properites


### M:StatusQuoBaseball.Utilities.Fraction.Duplicate

The function replicates current Fraction object


### M:StatusQuoBaseball.Utilities.Fraction.Equals(System.Object)

checks whether two fractions are equal


### M:StatusQuoBaseball.Utilities.Fraction.GCD(System.Int64,System.Int64)

The function returns GCD of two numbers (used for reducing a Fraction)


### M:StatusQuoBaseball.Utilities.Fraction.GetHashCode

returns a hash code for this fraction


### M:StatusQuoBaseball.Utilities.Fraction.Initialize(System.Int64,System.Int64)

Internal function for constructors


### M:StatusQuoBaseball.Utilities.Fraction.Inverse(StatusQuoBaseball.Utilities.Fraction)

The function returns the inverse of a Fraction object


### F:StatusQuoBaseball.Utilities.Fraction.m_iNumerator

Class attributes/members


### M:StatusQuoBaseball.Utilities.Fraction.Negate(StatusQuoBaseball.Utilities.Fraction)

internal function for negation


### P:StatusQuoBaseball.Utilities.Fraction.Numerator

Gets or sets the numerator.


### M:StatusQuoBaseball.Utilities.Fraction.op_Addition(frac1, frac2)

Adds a to a , yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to add. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to add. |


#### Returns

The that is the sum of the values of frac1 and frac2.


### M:StatusQuoBaseball.Utilities.Fraction.op_Addition(frac1, dbl)

Adds a to a , yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to add. |
| dbl | *System.Double*<br>The second to add. |


#### Returns

The that is the sum of the values of frac1 and dbl.


### M:StatusQuoBaseball.Utilities.Fraction.op_Addition(frac1, iNo)

Adds a to a , yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to add. |
| iNo | *System.Int32*<br>The second to add. |


#### Returns

The that is the sum of the values of frac1 and iNo.


### M:StatusQuoBaseball.Utilities.Fraction.op_Addition(dbl, frac1)

Adds a to a , yielding a new .

| Name | Description |
| ---- | ----------- |
| dbl | *System.Double*<br>The first to add. |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to add. |


#### Returns

The that is the sum of the values of dbl and frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_Addition(iNo, frac1)

Adds a to a , yielding a new .

| Name | Description |
| ---- | ----------- |
| iNo | *System.Int32*<br>The first to add. |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to add. |


#### Returns

The that is the sum of the values of iNo and frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_Division(frac1, frac2)

Computes the division of frac1 and frac2, yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to divide (the divident). |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The to divide (the divisor). |


#### Returns

The that is the frac1 / frac2.


### M:StatusQuoBaseball.Utilities.Fraction.op_Division(frac1, dbl)

Computes the division of frac1 and dbl, yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to divide (the divident). |
| dbl | *System.Double*<br>The to divide (the divisor). |


#### Returns

The that is the frac1 / dbl.


### M:StatusQuoBaseball.Utilities.Fraction.op_Division(frac1, iNo)

Computes the division of frac1 and iNo, yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to divide (the divident). |
| iNo | *System.Int32*<br>The to divide (the divisor). |


#### Returns

The that is the frac1 / iNo.


### M:StatusQuoBaseball.Utilities.Fraction.op_Division(dbl, frac1)

Computes the division of dbl and frac1, yielding a new .

| Name | Description |
| ---- | ----------- |
| dbl | *System.Double*<br>The to divide (the divident). |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to divide (the divisor). |


#### Returns

The that is the dbl / frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_Division(iNo, frac1)

Computes the division of iNo and frac1, yielding a new .

| Name | Description |
| ---- | ----------- |
| iNo | *System.Int32*<br>The to divide (the divident). |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to divide (the divisor). |


#### Returns

The that is the iNo / frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_Equality(frac1, frac2)

Determines whether a specified instance of is equal to another specified .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to compare. |


#### Returns

true if frac1 and frac2 are equal; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_Equality(frac1, dbl)

Determines whether a specified instance of is equal to another specified .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| dbl | *System.Double*<br>The second to compare. |


#### Returns

true if frac1 and dbl are equal; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_Equality(frac1, iNo)

Determines whether a specified instance of is equal to another specified .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| iNo | *System.Int32*<br>The second to compare. |


#### Returns

true if frac1 and iNo are equal; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_Explicit(StatusQuoBaseball.Utilities.Fraction)~System.Double

overloaed user defined conversions: from fractions to double and string


### M:StatusQuoBaseball.Utilities.Fraction.op_GreaterThan(frac1, frac2)

Determines whether one specified is greater than another specfied .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to compare. |


#### Returns

true if frac1 is greater than frac2; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_GreaterThanOrEqual(frac1, frac2)

Determines whether one specified is greater than or equal to another specfied .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to compare. |


#### Returns

true if frac1 is greater than or equal to frac2; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_Implicit(frac)~System.String

Ops the implicit.


#### Returns

The implicit.

| Name | Description |
| ---- | ----------- |
| frac | *StatusQuoBaseball.Utilities.Fraction*<br>Frac. |

### M:StatusQuoBaseball.Utilities.Fraction.op_Implicit(dNo)~StatusQuoBaseball.Utilities.Fraction

Ops the implicit.


#### Returns

The implicit.

| Name | Description |
| ---- | ----------- |
| dNo | *System.Double*<br>D no. |

### M:StatusQuoBaseball.Utilities.Fraction.op_Implicit(System.Int64)~StatusQuoBaseball.Utilities.Fraction

overloaed user defined conversions: from numeric data types to Fractions


### M:StatusQuoBaseball.Utilities.Fraction.op_Implicit(strNo)~StatusQuoBaseball.Utilities.Fraction

Ops the implicit.


#### Returns

The implicit.

| Name | Description |
| ---- | ----------- |
| strNo | *System.String*<br>String no. |

### M:StatusQuoBaseball.Utilities.Fraction.op_Inequality(frac1, frac2)

Determines whether a specified instance of is not equal to another specified .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to compare. |


#### Returns

true if frac1 and frac2 are not equal; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_Inequality(frac1, dbl)

Determines whether a specified instance of is not equal to another specified .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| dbl | *System.Double*<br>The second to compare. |


#### Returns

true if frac1 and dbl are not equal; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_Inequality(frac1, iNo)

Determines whether a specified instance of is not equal to another specified .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| iNo | *System.Int32*<br>The second to compare. |


#### Returns

true if frac1 and iNo are not equal; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_LessThan(frac1, frac2)

Determines whether one specified is lower than another specfied .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to compare. |


#### Returns

true if frac1 is lower than frac2; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_LessThanOrEqual(frac1, frac2)

Determines whether one specified is lower than or equal to another specfied .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The first to compare. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The second to compare. |


#### Returns

true if frac1 is lower than or equal to frac2; otherwise, false.


### M:StatusQuoBaseball.Utilities.Fraction.op_Multiply(frac1, frac2)

Computes the product of frac1 and frac2, yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to multiply. |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The to multiply. |


#### Returns

The that is the frac1 * frac2.


### M:StatusQuoBaseball.Utilities.Fraction.op_Multiply(frac1, dbl)

Computes the product of frac1 and dbl, yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to multiply. |
| dbl | *System.Double*<br>The to multiply. |


#### Returns

The that is the frac1 * dbl.


### M:StatusQuoBaseball.Utilities.Fraction.op_Multiply(frac1, iNo)

Computes the product of frac1 and iNo, yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to multiply. |
| iNo | *System.Int32*<br>The to multiply. |


#### Returns

The that is the frac1 * iNo.


### M:StatusQuoBaseball.Utilities.Fraction.op_Multiply(dbl, frac1)

Computes the product of dbl and frac1, yielding a new .

| Name | Description |
| ---- | ----------- |
| dbl | *System.Double*<br>The to multiply. |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to multiply. |


#### Returns

The that is the dbl * frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_Multiply(iNo, frac1)

Computes the product of iNo and frac1, yielding a new .

| Name | Description |
| ---- | ----------- |
| iNo | *System.Int32*<br>The to multiply. |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to multiply. |


#### Returns

The that is the iNo * frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_Subtraction(frac1, frac2)

Subtracts a from a , yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to subtract from (the minuend). |
| frac2 | *StatusQuoBaseball.Utilities.Fraction*<br>The to subtract (the subtrahend). |


#### Returns

The that is the frac1 minus frac2.


### M:StatusQuoBaseball.Utilities.Fraction.op_Subtraction(frac1, dbl)

Subtracts a from a , yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to subtract from (the minuend). |
| dbl | *System.Double*<br>The to subtract (the subtrahend). |


#### Returns

The that is the frac1 minus dbl.


### M:StatusQuoBaseball.Utilities.Fraction.op_Subtraction(frac1, iNo)

Subtracts a from a , yielding a new .

| Name | Description |
| ---- | ----------- |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to subtract from (the minuend). |
| iNo | *System.Int32*<br>The to subtract (the subtrahend). |


#### Returns

The that is the frac1 minus iNo.


### M:StatusQuoBaseball.Utilities.Fraction.op_Subtraction(dbl, frac1)

Subtracts a from a , yielding a new .

| Name | Description |
| ---- | ----------- |
| dbl | *System.Double*<br>The to subtract from (the minuend). |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to subtract (the subtrahend). |


#### Returns

The that is the dbl minus frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_Subtraction(iNo, frac1)

Subtracts a from a , yielding a new .

| Name | Description |
| ---- | ----------- |
| iNo | *System.Int32*<br>The to subtract from (the minuend). |
| frac1 | *StatusQuoBaseball.Utilities.Fraction*<br>The to subtract (the subtrahend). |


#### Returns

The that is the iNo minus frac1.


### M:StatusQuoBaseball.Utilities.Fraction.op_UnaryNegation(StatusQuoBaseball.Utilities.Fraction)

Operators for the Fraction object includes -(unary), and binary opertors such as +,-,*,/


### M:StatusQuoBaseball.Utilities.Fraction.ReduceFraction(StatusQuoBaseball.Utilities.Fraction)

The function reduces(simplifies) a Fraction object by dividing both its numerator and denominator by their GCD


### M:StatusQuoBaseball.Utilities.Fraction.ToDouble

The function returns the current Fraction object as double


### M:StatusQuoBaseball.Utilities.Fraction.ToFraction(System.Double)

The function takes a floating point number as an argument and returns its corresponding reduced fraction


### M:StatusQuoBaseball.Utilities.Fraction.ToFraction(System.String)

The function takes an string as an argument and returns its corresponding reduced fraction the string can be an in the form of and integer, double or fraction. e.g it can be like "123" or "123.321" or "123/456"


### M:StatusQuoBaseball.Utilities.Fraction.ToString

The function returns the current Fraction object as a string


### P:StatusQuoBaseball.Utilities.Fraction.Value

Sets the value.


## T:StatusQuoBaseball.Utilities.FractionException

Exception class for Fraction, derived from System.Exception


### M:StatusQuoBaseball.Utilities.FractionException.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Utilities.FractionException.#ctor(Message)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| Message | *System.String*<br>Message. |

### M:StatusQuoBaseball.Utilities.FractionException.#ctor(Message, InnerException)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| Message | *System.String*<br>Message. |
| InnerException | *System.Exception*<br>Inner exception. |

## T:StatusQuoBaseball.Utilities.ILoggable

Loggable class that will use a logger to write info to file.


### M:StatusQuoBaseball.Utilities.ILoggable.Log

Log this instance.


## T:StatusQuoBaseball.Utilities.InMemoryCSVFile

In memory CSV File.


### M:StatusQuoBaseball.Utilities.InMemoryCSVFile.#ctor(System.String,System.Int32,System.Boolean,System.Collections.Generic.List{System.String[]})

Initializes a new instance of the class.


### P:StatusQuoBaseball.Utilities.InMemoryCSVFile.FilePath

Gets the CSV file path.


### P:StatusQuoBaseball.Utilities.InMemoryCSVFile.FilePath1

Gets the file path1.


### P:StatusQuoBaseball.Utilities.InMemoryCSVFile.HeaderRow

Gets the header row. Will return an empty array if no header row.


### P:StatusQuoBaseball.Utilities.InMemoryCSVFile.Item(System.Int32)

Gets the line.


#### Returns

string[]

| Name | Description |
| ---- | ----------- |
| lineIndex | *Unknown type*<br>int |

### P:StatusQuoBaseball.Utilities.InMemoryCSVFile.LineCount

Gets the line count.


### P:StatusQuoBaseball.Utilities.InMemoryCSVFile.MaxColumns

Gets the max columns.


### M:StatusQuoBaseball.Utilities.InMemoryCSVFile.ReadCSVFile(filePath, delimiter, hasHeaderRow)

Reads the CSV File.


#### Returns

InMemoryCSVFile

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |
| delimiter | *System.Boolean*<br>char |
| hasHeaderRow | *System.Char*<br>bool |

## T:StatusQuoBaseball.Utilities.Logger

Logger.


### M:StatusQuoBaseball.Utilities.Logger.#ctor(filePath)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |

### F:StatusQuoBaseball.Utilities.Logger.FILE_EXTENSION

The file extension.


### P:StatusQuoBaseball.Utilities.Logger.FilePath

Gets the file path.


### M:StatusQuoBaseball.Utilities.Logger.LogMessage(msg)

Writes to log.


#### Returns

The to log.

| Name | Description |
| ---- | ----------- |
| msg | *System.String*<br>Message. |

### M:StatusQuoBaseball.Utilities.Logger.WriteToFile

Write information to file.


#### Returns

The to log.


## T:StatusQuoBaseball.Utilities.MarkdownFromXMLGenerator

Generate Markdown text from XML file.


### M:StatusQuoBaseball.Utilities.MarkdownFromXMLGenerator.#ctor

Initializes a new instance of the class.


### M:StatusQuoBaseball.Utilities.MarkdownFromXMLGenerator.ToMarkdown(sw, root)

Convert XML to Markdown.

| Name | Description |
| ---- | ----------- |
| sw | *System.IO.StringWriter*<br>StringWriter |
| root | *System.Xml.Linq.XElement*<br>XElement |

### M:StatusQuoBaseball.Utilities.MarkdownFromXMLGenerator.ToMarkdown(filePath)

Converts XML to Markdown.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |

### M:StatusQuoBaseball.Utilities.MarkdownFromXMLGenerator.ToMarkdownFile(xmlFilePath)

Creates a markdown file from an xml file.


#### Remarks

Returns the number of characters written to the file.


#### Returns

int

| Name | Description |
| ---- | ----------- |
| xmlFilePath | *System.String*<br>string |

## T:StatusQuoBaseball.Utilities.OrdinalNumberGenerator

Ordinal number generator.


### M:StatusQuoBaseball.Utilities.OrdinalNumberGenerator.Generate(number)

Initializes the class.

| Name | Description |
| ---- | ----------- |
| number | *System.Int32*<br>Number. |

## T:StatusQuoBaseball.Utilities.SABRMetricsManager

Class to hold historical FIP values.


### M:StatusQuoBaseball.Utilities.SABRMetricsManager.GetFIPConstantByYear(year)

Gets the FIPC onstant by year.


#### Returns

double

| Name | Description |
| ---- | ----------- |
| year | *System.Int32*<br>int |

### M:StatusQuoBaseball.Utilities.SABRMetricsManager.Init(filePath, hasHeaderRow)

Init the specified filePath and hasHeaderRow.

| Name | Description |
| ---- | ----------- |
| filePath | *System.String*<br>string |
| hasHeaderRow | *System.Boolean*<br>If set to true has header row. |

## T:StatusQuoBaseball.Utilities.SerializationMethods

Serialization methods for Serializable classes.


### M:StatusQuoBaseball.Utilities.SerializationMethods.DeserializeFromStream(stream)

Deserializes an object from a MemoryStream.


#### Remarks

This function will not close the MemoryStream object passed in.


#### Returns

MemoryStream

| Name | Description |
| ---- | ----------- |
| stream | *System.IO.MemoryStream*<br>object |

### M:StatusQuoBaseball.Utilities.SerializationMethods.SerializeToFile(obj, filePath)

Serializes to file.


#### Returns

long

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>object |
| filePath | *System.String*<br>string |

### M:StatusQuoBaseball.Utilities.SerializationMethods.SerializeToStream(o)

Serializes object to a MemoryStream.


#### Returns

MemoryStream

| Name | Description |
| ---- | ----------- |
| o | *System.Object*<br>object |

## T:StatusQuoBaseball.Utilities.TextFillJustification

Text fill justification.


### F:StatusQuoBaseball.Utilities.TextFillJustification.Center

Center Justification


### F:StatusQuoBaseball.Utilities.TextFillJustification.Left

Left Justification


### F:StatusQuoBaseball.Utilities.TextFillJustification.Right

Right Justification


## T:StatusQuoBaseball.Utilities.TextUtilities

Text.


### M:StatusQuoBaseball.Utilities.TextUtilities.FillString(s, filler, totalLength, justification)

Fills the string.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| s | *System.String*<br>string |
| filler | *System.Char*<br>string |
| totalLength | *System.UInt32*<br>uint |
| justification | *StatusQuoBaseball.Utilities.TextFillJustification*<br>TextFillJustification. |

### M:StatusQuoBaseball.Utilities.TextUtilities.FormFilePathName(directory, info, extension)

Forms the name of the file path.


#### Returns

The file path name.

| Name | Description |
| ---- | ----------- |
| directory | *System.String*<br>Directory. |
| info | *System.String*<br>Info. |
| extension | *System.String*<br>Extension. |

### M:StatusQuoBaseball.Utilities.TextUtilities.GetIndicesOfChar(theString, theChar)

Gets the indices of char in a string.


#### Returns

int[]

| Name | Description |
| ---- | ----------- |
| theString | *System.String*<br>string |
| theChar | *System.Char*<br>char |

### M:StatusQuoBaseball.Utilities.TextUtilities.GetLengthOfLongestString(strings)

Gets the length of longest string.


#### Returns

The length of longest string.

| Name | Description |
| ---- | ----------- |
| strings | *System.String[]*<br>int |

### M:StatusQuoBaseball.Utilities.TextUtilities.ProgressBar(iteration, loops, filler, symbol)

Text-based progress bar


#### Returns

string

| Name | Description |
| ---- | ----------- |
| iteration | *System.Int32*<br>int |
| loops | *System.Int32*<br>int |
| filler | *System.Char*<br>char |
| symbol | *System.Char*<br>char |

### M:StatusQuoBaseball.Utilities.TextUtilities.ProgressBar(msg, iteration, loops, interval, filler, symbol)

Text-based progress bar.


#### Returns

string

| Name | Description |
| ---- | ----------- |
| msg | *System.String*<br>string |
| iteration | *System.Int32*<br>int |
| loops | *System.Int32*<br>int |
| interval | *System.Int32*<br>int |
| filler | *System.Char*<br>char |
| symbol | *System.Char*<br>char |
