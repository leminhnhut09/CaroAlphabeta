using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class Minimax
    {
        // điểm đánh giá
        public static int evaluationCount = 0;
        private static int winScore = 100000000;
        public static int WinScore
        {
            get { return Minimax.winScore; }
            set { Minimax.winScore = value; }
        }

        OCo[,] board;

        public OCo[,] Board
        {
            get { return board; }
            set { board = value; }
        }

        public Minimax(OCo[,] board)
        {
            this.board = board;
        }


        // Hàm tính tỉ số của max so với min
        public static double evaluateBoardForWhite(OCo[,] banCo, bool blacksTurn)
        {
            evaluationCount++;

            // lấy bảng điểm của 2 người chơi
            double blackScore = getScore(banCo, true, blacksTurn);
            double whiteScore = getScore(banCo, false, blacksTurn);

            if (blackScore == 0) blackScore = 1.0;

            // Tính điểm tương đối của màu trắng so với màu đen
            return whiteScore / blackScore;
        }



       // Tính điểm của bàn cờ
        public static int getScore(OCo[,] banCo, bool forBlack, bool blacksTurn)
        {
            // Tính điểm cho từng hướng trong 3 hướng
            return evaluateHorizontal(banCo, forBlack, blacksTurn) +
                    evaluateVertical(banCo, forBlack, blacksTurn) +
                    evaluateDiagonal(banCo, forBlack, blacksTurn);
        }

        // Hàm trả về vị trí có điểm tốt nhất (max)
        public int[] calculateNextMove(int depth)
        {

            int[] move = new int[2];

            Object[] bestMove = searchWinningMove(board);

            if (bestMove != null)
            {
                move[0] = (int)(bestMove[1]);
                move[1] = (int)(bestMove[2]);
            }
            else
            {
                bestMove = minimaxSearchAB(depth, board, true, -1.0, winScore);

                if (bestMove[1] == null)
                {
                    move = null;
                }
                else
                {
                    move[0] = (int)(bestMove[1]);
                    move[1] = (int)(bestMove[2]);
                }
            }

            evaluationCount = 0;

            return move;
        }
        private Object[] searchWinningMove(OCo[,] banCo)
        {
            List<OCo> allPossibleMoves = generateMoves(banCo);
            Object[] winningMove = new Object[3];

            foreach (OCo move in allPossibleMoves)
            {
                evaluationCount++;

                OCo[,] dummyBoard = CopyBoard(banCo);

                dummyBoard[move.Dong, move.Cot].SoHuu = 1;

                if (getScore(dummyBoard, false, false) >= winScore)
                {
                    winningMove[1] = move.Dong;
                    winningMove[2] = move.Cot; ;
                    return winningMove;
                }
            }
            return null;
        }


        /*
         * alpha: Di chuyển AI tốt nhất (Tối đa)
         * beta: Di chuyển của người chơi tốt nhất (Tối thiểu)
         * trả về: {điểm, di chuyển [0], di chuyển [1]}
         * */
        private static Object[] minimaxSearchAB(int depth, OCo[,] banCo, bool max, double alpha, double beta)
        {
            if (depth == 0)
            {
                Object[] x = { evaluateBoardForWhite(banCo, !max), null, null };
                return x;
            }

            List<OCo> allPossibleMoves = generateMoves(banCo);

            // Nếu không thể di chuyển sang trái, hãy coi nút này như một nút đầu cuối và trả về điểm số.
            if (allPossibleMoves.Count == 0)
            {
                Object[] x = { evaluateBoardForWhite(banCo, !max), null, null };
                return x;
            }

            Object[] bestMove = new Object[3];

            if (max)
            {
                // Khởi tạo bước di chuyển tốt nhất bắt đầu.
                bestMove[0] = -1.0;
                foreach (OCo move in allPossibleMoves)
                {
                    OCo[,] dummyBoard = CopyBoard(banCo);

                    // Đánh vào bàn cờ mới với người chơi là max
                    dummyBoard[move.Dong, move.Cot].SoHuu = 1;

                    Object[] tempMove = minimaxSearchAB(depth - 1, dummyBoard, !max, alpha, beta);
                    
                    // Cập nhật alpha
                    if ((Double)(tempMove[0]) > alpha)
                    {
                        alpha = (Double)(tempMove[0]);
                    }
                    // Cắt tỉa alpha
                    if ((Double)(tempMove[0]) >= beta)
                    {
                        return tempMove;
                    }

                    // Tìm nước đi điểm cao nhất
                    if ((Double)tempMove[0] > (Double)bestMove[0])
                    {
                        bestMove = tempMove;
                        bestMove[1] = move.Dong;
                        bestMove[2] = move.Cot;
                    }
                }
            }
            else
            {
                // Khởi tạo nước đi tốt nhất bắt đầu bằng nước đi đầu tiên trong danh sách và + điểm vô cực.
                bestMove[0] = 100000000.0;
                bestMove[1] = allPossibleMoves[0].Dong;
                bestMove[2] = allPossibleMoves[0].Cot;

                foreach (OCo move in allPossibleMoves)
                {

                    OCo[,] dummyBoard = CopyBoard(banCo);
                    dummyBoard[move.Dong, move.Cot].SoHuu = 2;

                    Object[] tempMove = minimaxSearchAB(depth - 1, dummyBoard, !max, alpha, beta);

                    // Cập nhật beta

                    if (((Double)tempMove[0]) < beta)
                    {
                        beta = (Double)(tempMove[0]);
                    }
                    // Cắt tỉa beta
                    if ((Double)(tempMove[0]) <= alpha)
                    {
                        return tempMove;
                    }

                    // Tìm vị trí có điểm thấp nhất
                    if ((Double)tempMove[0] < (Double)bestMove[0])
                    {
                        bestMove = tempMove;
                        bestMove[1] = move.Dong;
                        bestMove[2] = move.Cot;
                    }
                }
            }

            // Trả lại nước đi tốt nhất được tìm thấy trong độ sâu này
            return bestMove;
        }

        public static OCo[,] CopyBoard(OCo[,] banCoChinh)
        {
            OCo[,] banCo = new OCo[banCoChinh.GetLength(0), banCoChinh.GetLength(1)];
            for (int i = 0; i < banCoChinh.GetLength(0); i++)
            {
                for (int j = 0; j < banCoChinh.GetLength(1); j++)
                {
                    banCo[i, j] = new OCo(banCoChinh[i, j].Dong, banCoChinh[i, j].Cot, banCoChinh[i, j].ViTri, banCoChinh[i, j].SoHuu);
                }
            }
            return banCo;
        }

        // Trả về danh sách các nước chưa đi và có các giá trị xung quanh
        // Mục tiêu: dựa vào các nước đã đánh tìm các ô trống lân cận
        public static List<OCo> generateMoves(OCo[,] boardMatrix)
        {
            List<OCo> moveList = new List<OCo>();

            int boardSize = boardMatrix.GetLength(0);


            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    // Bỏ qua các ô đã đánh
                    if (boardMatrix[i, j].SoHuu > 0) continue;
                    if (i > 0)
                    {
                        if (j > 0)
                        {
                            if (boardMatrix[i - 1, j - 1].SoHuu > 0 ||
                               boardMatrix[i, j - 1].SoHuu > 0)
                            {
                                OCo move = new OCo(boardMatrix[i, j].Dong, boardMatrix[i, j].Cot, boardMatrix[i, j].ViTri, boardMatrix[i, j].SoHuu);
                                moveList.Add(move);
                                continue;
                            }
                        }

                        if (j < boardSize - 1)
                        {
                            if (boardMatrix[i - 1, j + 1].SoHuu > 0 ||
                               boardMatrix[i, j + 1].SoHuu > 0)
                            {
                                OCo move = new OCo(boardMatrix[i, j].Dong, boardMatrix[i, j].Cot, boardMatrix[i, j].ViTri, boardMatrix[i, j].SoHuu);
                                moveList.Add(move);
                                continue;
                            }
                        }

                        if (boardMatrix[i - 1, j].SoHuu > 0)
                        {
                            OCo move = new OCo(boardMatrix[i, j].Dong, boardMatrix[i, j].Cot, boardMatrix[i, j].ViTri, boardMatrix[i, j].SoHuu);
                            moveList.Add(move);
                            continue;
                        }
                    }

                    if (i < boardSize - 1)
                    {
                        if (j > 0)
                        {
                            if (boardMatrix[i + 1, j - 1].SoHuu > 0 ||
                               boardMatrix[i, j - 1].SoHuu > 0)
                            {

                                OCo move = new OCo(boardMatrix[i, j].Dong, boardMatrix[i, j].Cot, boardMatrix[i, j].ViTri, boardMatrix[i, j].SoHuu);
                                moveList.Add(move);
                                continue;
                            }
                        }
                        // 2 ô kề phải
                        if (j < boardSize - 1)
                        {
                            if (boardMatrix[i + 1, j + 1].SoHuu > 0 ||
                               boardMatrix[i, j + 1].SoHuu > 0)
                            {
                                OCo move = new OCo(boardMatrix[i, j].Dong, boardMatrix[i, j].Cot, boardMatrix[i, j].ViTri, boardMatrix[i, j].SoHuu);
                                moveList.Add(move);
                                continue;
                            }
                        }
                        // ô ở dưới hàng học
                        if (boardMatrix[i + 1, j].SoHuu > 0)
                        {
                            OCo move = new OCo(boardMatrix[i, j].Dong, boardMatrix[i, j].Cot, boardMatrix[i, j].ViTri, boardMatrix[i, j].SoHuu);
                            moveList.Add(move);
                            continue;
                        }
                    }

                }
            }
            return moveList;

        }


        /* Đánh giá theo hàng ngang
         *
         * Block: - bị chặn 2 đầu => 2
         *        - bị chặn 1 đầu => 1
         *        - không bị chặn => 0
         * */
        public static int evaluateHorizontal(OCo[,] boardMatrix, bool forBlack, bool playersTurn)
        {

            int consecutive = 0;
            int blocks = 2;
            int score = 0;

            for (int i = 0; i < boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < boardMatrix.GetLength(1); j++)
                {
                    // Nếu là viên đá của người chơi (max hoặc min)
                    if (boardMatrix[i, j].SoHuu == (forBlack ? 2 : 1))
                    {
                        consecutive++;
                    }
                    else if (boardMatrix[i, j].SoHuu == 0)
                    {
                        // Kiểm tra xem có liên tiếp trước ô trống không
                        if (consecutive > 0)
                        {
                            // Ô hiện tại trống, các ô trước đã liên tiếp => bị chặn - 1
                            blocks--;
                            // Tính điểm cho tập liên tiếp
                            score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                            // Khởi tạo liên tiếp mới   
                            consecutive = 0;
                            // Ô hiện tại trống, tập liên tiếp tiếp theo sẽ có nhiều nhất 1 cạnh bị chặn.
                            blocks = 1;
                        }
                        else
                        {
                            // Ô hiện tại trống, tập liên tiếp tiếp theo sẽ có nhiều nhất 1 cạnh bị chặn.
                            blocks = 1;
                        }
                    }
                    // Ô này gặp địch
                    else if (consecutive > 0)
                    {
                        // Tính điểm cho tập liên tiếp
                        score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                        // Khởi tạo liên tiếp mới   
                        consecutive = 0;
                        // Ô này gặp địch, dãy tiếp theo xấu nhất sẽ bị chặn 2 đầu
                        blocks = 2;
                    }
                    else
                    {
                        // Ô này gặp địch, dãy tiếp theo xấu nhất sẽ bị chặn 2 đầu
                        blocks = 2;
                    }
                }
               // Hết 1 hàng
                if (consecutive > 0)
                {
                    score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                }
                // Cập nhật để quét hàng mới
                consecutive = 0;
                blocks = 2;
            }
            return score;
        }


        /* Đánh giá theo hàng dọc
         *
         * Block: - bị chặn 2 đầu => 2
         *        - bị chặn 1 đầu => 1
         *        - không bị chặn => 0
         * */
        public static int evaluateVertical(OCo[,] boardMatrix, bool forBlack, bool playersTurn)
        {

            int consecutive = 0;
            int blocks = 2;
            int score = 0;

            for (int j = 0; j < boardMatrix.GetLength(0); j++)
            {
                for (int i = 0; i < boardMatrix.GetLength(1); i++)
                {
                    if (boardMatrix[i, j].SoHuu == (forBlack ? 2 : 1))
                    {
                        consecutive++;
                    }
                    else if (boardMatrix[i, j].SoHuu == 0)
                    {
                        if (consecutive > 0)
                        {
                            blocks--;
                            score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                            consecutive = 0;
                            blocks = 1;
                        }
                        else
                        {
                            blocks = 1;
                        }
                    }
                    else if (consecutive > 0)
                    {
                        score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                        consecutive = 0;
                        blocks = 2;
                    }
                    else
                    {
                        blocks = 2;
                    }
                }
                if (consecutive > 0)
                {
                    score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);

                }
                consecutive = 0;
                blocks = 2;

            }
            return score;
        }


        /* Đánh giá theo hai đường chéo
        *
        * Block: - bị chặn 2 đầu => 2
        *        - bị chặn 1 đầu => 1
        *        - không bị chặn => 0
        * */
        public static int evaluateDiagonal(OCo[,] boardMatrix, bool forBlack, bool playersTurn)
        {

            int consecutive = 0;
            int blocks = 2;
            int score = 0;
            // Từ dưới cùng bên trái sang trên cùng bên phải theo đường chéo(chéo phụ)
            for (int k = 0; k <= 2 * (boardMatrix.GetLength(0) - 1); k++)
            {
                int iStart = Math.Max(0, k - boardMatrix.GetLength(0) + 1);
                int iEnd = Math.Min(boardMatrix.GetLength(1) - 1, k);
                for (int i = iStart; i <= iEnd; ++i)
                {
                    int j = k - i;

                    if (boardMatrix[i, j].SoHuu == (forBlack ? 2 : 1))
                    {
                        consecutive++;
                    }
                    else if (boardMatrix[i, j].SoHuu == 0)
                    {
                        if (consecutive > 0)
                        {
                            blocks--;
                            score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                            consecutive = 0;
                            blocks = 1;
                        }
                        else
                        {
                            blocks = 1;
                        }
                    }
                    else if (consecutive > 0)
                    {
                        score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                        consecutive = 0;
                        blocks = 2;
                    }
                    else
                    {
                        blocks = 2;
                    }

                }
                if (consecutive > 0)
                {
                    score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);

                }
                consecutive = 0;
                blocks = 2;
            }
            // Từ trên cùng bên trái đến dưới cùng bên phải theo đường chéo(chéo chính)
            for (int k = 1 - boardMatrix.GetLength(0); k < boardMatrix.GetLength(0); k++)
            {
                int iStart = Math.Max(0, k);
                int iEnd = Math.Min(boardMatrix.GetLength(0) + k - 1, boardMatrix.GetLength(0) - 1);
                for (int i = iStart; i <= iEnd; ++i)
                {
                    int j = i - k;

                    if (boardMatrix[i, j].SoHuu == (forBlack ? 2 : 1))
                    {
                        consecutive++;
                    }
                    else if (boardMatrix[i, j].SoHuu == 0)
                    {
                        if (consecutive > 0)
                        {
                            blocks--;
                            score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                            consecutive = 0;
                            blocks = 1;
                        }
                        else
                        {
                            blocks = 1;
                        }
                    }
                    else if (consecutive > 0)
                    {
                        score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);
                        consecutive = 0;
                        blocks = 2;
                    }
                    else
                    {
                        blocks = 2;
                    }

                }
                if (consecutive > 0)
                {
                    score += getConsecutiveSetScore(consecutive, blocks, forBlack == playersTurn);

                }
                consecutive = 0;
                blocks = 2;
            }
            return score;
        }

        
        // Hàm tính điểm theo số quân cờ liên tiếp theo số bên bị chặn
        public static int getConsecutiveSetScore(int count, int blocks, bool currentTurn)
        {
            int winGuarantee = 1000000;

            if (blocks == 2 && count < 5) return 0;

            switch (count)
            {
                case 5:
                    {
                        return winScore;
                    }
                case 4:
                    {
                        // Là lượt của mình => win
                        if (currentTurn) return winGuarantee;
                        else
                        {
                            // 4 con mà không bị chặn
                            if (blocks == 0) return winGuarantee / 4;
                            // 4 con mà bị chặn 1 đầu
                            else return 200;
                        }
                    }
                case 3:
                    {
                        if (blocks == 0)
                        {
                            if (currentTurn) return 50000;
                            else return 200;
                        }
                        else
                        {
                            if (currentTurn) return 10;
                            else return 5;
                        }
                    }
                case 2:
                    {
                        if (blocks == 0)
                        {
                            if (currentTurn) return 7;
                            else return 5;
                        }
                        else
                        {
                            return 3;
                        }
                    }
                case 1:
                    {
                        return 1;
                    }
            }

            // Nhiều hơn 5 viên đá liên tiếp
            return winScore * 2;
        }


    }
}
