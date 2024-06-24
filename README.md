# BRR Suite GUI

This app is a user-friendly[^1] GUI employing my [BRR Suite library](https://github.com/spannerisms/BRRSuite). This library is available for anyone to use.

BRR Suite requires the .NET 8.0 runtime.

[^1]: At least when that user is me.


## My process
As of now, this doesn't provide any fancy features over BRRtools. The main reason I wrote this is because my workflow&mdash;which involved batch files to create hundreds or thousands of tests)&mdash;was getting extremely tedious. This application improved pretty much everything about what I was doing. It's faster. It's easier to manage files (mostly due to not needing to make a billion of them). And most of it is in a compact GUI. 

Here's a rough step-by-step of what I do:

1. Create or open a WAV file in [https://www.audacityteam.org/](Audacity) or another similarly-featureful tool.
2. Modify the WAV to suit your needs. This sublist details my preferences:
     - Change the project rate to 32000 Hz, only because that maps better to the BRR output
     - Trim leading 0s off the front of the sample (although BRR Suite can also do that now)
     - Truncate the sample to about 0.1 seconds. Longer files end up too big for my tastes after conversion. BRR Suite (and BRRtools) can truncate the file themselves, but I find it easier to work with when it's smaller.
     - Use Effect>Normalize to remove any DC offset
     - Use Effect>Amplify to make the waveform as loud as possible
3. Save to audio to a `.wav` file with the name I intend to use with my SNES code.
4. Set the `Trim to` field to a 0 or close-to-zero sample, with the number found using Audacity. This should give enough room for the waveform to loop nicely, but ideally as close to the beginning as possible for a smaller output.
5. Set the `First loop sample` field to a 0 or close-to-zero sample as close to the beginning as possible that looks like it could smoothly transition in from the selected endpoint.
6. Click `Create loop candidates`
7. Trawl through all the candidates in the `Listen` box. If any candidate sounds good or close to good, I write down its `Loop start input` in the `SCRATCH` area.
8. After every candidate has been listened to, take one value from the SCRATCH area and set it as the `Loop sample` in the `Fine adjustments` box.
9. Listen to the samples generated for any that sound perfect, not just "good". If a perfect sample is found:
     - Re-examine the audio for any quiet buzzing or other anomalies.
     - If, like me, you prefer tuning everything to C, and the pitch sounds off, have the `Export WAV` box checked and check the frequency with Effect>Change Pitch.
     - Export the `.brr` file to my `/brr` repository and test it with a test song in my homebrew SPC engine.
     - If the sample reveals flaws in an emulator, I delete it. Otherwise I keep it.
     - If another sample is good, I'll take the smaller one, the one that sounds better, or just name one of them `{instrument}2`
10. Repeat Step 8 for each loop point that was noted down.
11. If I'm still not satisfied, repeat from Step 4 or Step 5 with new parameters.

# Interface
**`WAV file`** - The input audio file to use for encoding. This should be a 16-bit, 1 channel, PCM WAV file.

**`↻`** - The refresh button can be used to reload the file whose path is already saved.

**`Name`** - A simple name for the file. Defaults to the name of the selected WAV file when loaded.

**`Output`** - The folder where any exported files will be saved. This location is saved across sessions.

**`Cancel`** - While any encoding process is ongoing, most of the interface will be disabled. The progress bar on the bottom of the form displays an estimate for the task. This button can be used to cancel a large task (although it will finish its current encoding or decoding subtask before it can respond to such a request).

## Menu bar
### Window
**`Frequency cheat sheet`** - Opens a window that shows the frequency of notes in concert pitch (A440).

----

### Help
**`Acknowledgements`** - Info about this program's development.

## Input
**`Sample rate`** (read only) - The sample rate of the file in hertz

**`Fidelity`** (read only) - The number of bits per sample

**`Length`** (read only) - The length of the file, in samples

**`Trim to`** - The number of samples that should be used for conversion. Defaults to the length of the audio when initially loaded.

**`Trim lead zeros`** - When checked, the encoder will remove all the zeros at the beginning of the audio and add back what is necessary for alignment before converting.

**`Find zero crossings`** - Scans the audio from the first loop sample to the trim point for locations where the amplitude of the waveform is zero or flips sign and outputs those sample locations to the box below.

**`SCRATCH`** - Use this box for whatever you want.

## Output
**`Est. size`** (read only) - The estimated size of the output BRR. Resampling may add or remove a small number of blocks, and trimming leading zeros can theoretically make the estimate wrong to an arbitrary degree.

**`Resample to`** - The sample frequency used for encoding. Allows selecting between 4, 8, 16, and 32 kilohertz.

The SNES sound system's DSP expects samples to be 32000Hz; however, encoding at lower frequencies has uses.

Pros of lower frequencies:
- Smaller sample
- Inherently higher transposition allows better use of the upper registers

Cons of lower frequencies:
- Lower fidelity
- Generally quieter
- Harder to find loop points (sometimes)

----

**`Interpolation`** - The algorithm used for resampling.
- None
- Linear
- Sinusoidal
- Cubic
- Band-limited (best quality)

**`Create unlooped`** - Creates four unlooped BRRs, one for each of the available encoding frequencies.

**`Treble boost`** - Selects a treble boost filter to compensate for the Gaussian low pass of the SNES.

**`Force silence at start`** - Forces block 0 of the BRR to be all silent samples, allowing the first block of audio to use any filter. This may produce marginally better samples at the expense of size.

## Loop search
The loop search functionality allows you to prospect a large number of candidate loop points starting from a given point.

**`First loop sample`** - The sample of the first start point to be checked for. This is relative the input file at the input frequency.

**`Attempt count`** - The number of start points to attempt.

**`Increment`** - Distance between start point attempts.

**`Range`** - The number of samples above and below the start point to include with each attempt.

**`Create loop candidates`** - Begins the loop search process. 

For example, with a `First loop sample` of 100, an `Attempt count` of 3, an `Increment` of 10 and a `Range` of 2, the following samples will be attempted as the loop point:
> [98, 99, **100**, 101, 102], [108, 109, **110**, 111, 112], [118, 119, **120**, 121, 122]

Any loop sample points that fall outside the range of the sample as a whole will be skipped.

As candidates are created, they will populate the candidates list in the `Listen` area named as: `<wavname>_<kHz>_<loopsample>`.

## Fine adjustments
When a loop point is good, but not good enough, retrying it with other trim points can often lead to better results (but no guarantee of perfect results).

**`Loop samples`** - The sample of the loop point to retest.

**`Range`** - The number of trim points above and below to test with this loop.

**`Adjust`** - Begins the adjustment process.

For example, with a `Loop sample` of 100, a `Trim to` of 1000, and a `Range` of 10; 21 candidates will be created, with the input trimmed from 90 samples and up to and including 110 samples.

As candidates are created, they will populate the candidates list in the `Listen` area named as: `<wavname>_<kHz>_p<loopsample>t<trim>`.

## Listen
**`Export`** - This button will save the desired files to the output folder with the given name and appropriate extension. The default name of a file will be `<wavname>_<kHz>_<loopblock>`.

**`Play`** - Plays the sample to hear how it sounds

**`Auto-play`** - Automatically play a sample as it is selected.

**`Stop`** - Stops the audio.

> [!TIP]
> Irrespective of the auto-play setting, double clicking a candidate in the list will play its audio.


**`Export BRR`** - Exports a BRR file with the extension `.brr` to the output directory.

BRR samples can be exported in three different formats, which are detailed in the [Library's README](https://github.com/spannerisms/BRRSuite/blob/main/README.md)

**`Export WAV`** - Exports the preview audio with the extension `.wav` to the output directory.