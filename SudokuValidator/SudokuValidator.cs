public class Solution {
    public bool IsValidSudoku(char[][] board) {

        // check rows
        for (int i = 0; i < 9; i++) {
            if (!IsValidSubStruct(board[i])) {
                return false;
            }
        }
        
        // check columns
        char[] toBeChecked;
        
        for (int i = 0; i < 9; i++) {
            toBeChecked = new char[9] {
                            board[0][i], board[1][i], board[2][i], board[3][i],
                            board[4][i], board[5][i], board[6][i], board[7][i],
                            board[8][i]
            };
            
            if (!IsValidSubStruct(toBeChecked)) {
                return false;
            }
        }
        
        // check grids
        for (int i = 0; i < 9; i += 3) {
            for (int j = 0; j < 9; j += 3) {
                toBeChecked = new char[9] {
                    board[j][i],   board[j][i+1],   board[j][i+2],
                    board[j+1][i], board[j+1][i+1], board[j+1][i+2],
                    board[j+2][i], board[j+2][i+1], board[j+2][i+2]
                };

                if (!IsValidSubStruct(toBeChecked)) {
                    return false;
                }
            }
        }
        
        return true;
    }
    
    // returns true if row, column, or grid is valid
    public bool IsValidSubStruct(char[] subStruct) {
        bool isValid = true;
        char[] numbers = new char[9] {
            '1','2', '3',
            '4', '5', '6',
            '7', '8', '9'
        };
        
        int index;
        for (int i = 0; i < subStruct.Length; i++) {
            if (numbers.Contains(subStruct[i])) {
                index = (int) Char.GetNumericValue(subStruct[i]);
                Console.WriteLine(index);
                numbers[index - 1] = '-';
                continue;
            } else if (subStruct[i] == '.') {
                continue;
            } else {
                isValid = false;
                break;
            }
        }
        
        return isValid;
        
    }
    
}