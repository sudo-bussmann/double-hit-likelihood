# double-hit-likelihood
How fast will two random positive integers duplicate in a range of 0 to Z over N cycles.

One morning where I could not sleep I was watching an IAmTimCorey video on Dependency Injection and when using a Transient lifetime for an object he hit the same integer, between 1 and 1000, three times within one video.
Thought to myself that morning, "I wonder what the likelihood of that happening is." So I built this small console app to test out that.

arg[1] = integer for max range desired ( ex: 1000 )
arg[2] = integer for number of cycles ( ex: 100 )

Results are the measures of central tendency (mean, median, mode) over the course of those cycles.

If the number of cycles is >= 1000, the result values where the match was found goes from raw list of values to a list of value pairs (number found : how many times it was hit).

Was surprised to find that for the original premise, tendency for hitting the same number twice in a range of 1000 converges to 40 with an std of ~20. Was pleasantly surprised but also found this very cool. :D
