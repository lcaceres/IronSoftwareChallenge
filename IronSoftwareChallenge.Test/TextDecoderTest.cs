using IronSoftwareChallenge.Utils;

namespace IronSoftwareChallenge.Test
{
    public class TextDecoderTest
    {
        [Theory]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void TextDecoder_ChallengeExamples_ShouldReturnExpected(string input, string expected)
        {
            var actual = TextDecoder.Decode(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2*2#", "A")]
        [InlineData("222*#", "")] 
        [InlineData("222*2#", "A")]
        [InlineData("22 33*3#", "BD")]
        [InlineData("33*33#", "E")]
        [InlineData("33 2 2*#", "EA")]
        [InlineData("2 2 2*#", "AA")]
        [InlineData("22*22#", "B")]
        [InlineData("222*22#", "B")]
        [InlineData("33 2*#", "E")]
        public void TextDecoder_AsteriskCharacter_ShouldReturnExpected2(string input, string expected)
        {
            var actual = TextDecoder.Decode(input);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("202#", "A A")]
        [InlineData("2002#", "A A")]
        [InlineData("2220", "C")]
        [InlineData("0222#", "C")]
        [InlineData("220222#", "B C")]
        [InlineData("000#", "")]
        [InlineData("0*", "")]
        public void TextDecoder_SpaceCharacter_ShouldBeHandledCorrectly(string input, string expected)
        {
            var actual = TextDecoder.Decode(input);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("A#", "?")]
        [InlineData("!#", "?")]
        [InlineData("2A2#", "A?A")]
        [InlineData("2 2$2#", "AA?A")]
        [InlineData("33X33#", "E?E")]
        [InlineData("??#", "?")]
        [InlineData("@#", "?")]
        public void TextDecoder_InvalidCharacters_ShouldReturnQuestionMarks(string input, string expected)
        {
            var actual = TextDecoder.Decode(input);
            Assert.Equal(expected, actual);
        }
    }
}