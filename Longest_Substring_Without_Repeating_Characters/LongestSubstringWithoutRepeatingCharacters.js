/**
 * @param {string} s
 * @return {number}
 */
 var lengthOfLongestSubstring = function(s) {
    let charsSoFar = [];
    let longestSubstringLength = 0;
    let currentSubstringLength = 0;
    for (let i = 0; i < s.length; i++) {

        if (charsSoFar.includes(s.charAt(i))) {
            // we want to go back to the index OF THE WHOLE STRING right before the last occurence of current char
            i = getIndexOfCharFromTheBack(s, s.charAt(i), i);
            charsSoFar = [];
            if (currentSubstringLength > longestSubstringLength) {
                longestSubstringLength = currentSubstringLength;
            }
            currentSubstringLength = 0;
        }

        charsSoFar.push(s.charAt(i));
        currentSubstringLength++;
    }

    if (currentSubstringLength > longestSubstringLength) {
        longestSubstringLength = currentSubstringLength;
    }

    return longestSubstringLength;
};


var getIndexOfCharFromTheBack = function(s, c, currIndex) {
    for (let i = currIndex - 1; i >= 0; i--) {
        if (s.charAt(i) === c) {
            return i + 1;
        }
    }
}

console.log(lengthOfLongestSubstring("abcabcbb"));
console.log(lengthOfLongestSubstring("bbbbb"));
console.log(lengthOfLongestSubstring("pwwkew"));
console.log(lengthOfLongestSubstring("")); // 0
console.log(lengthOfLongestSubstring("dvdf")); // 3