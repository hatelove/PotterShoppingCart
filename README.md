TDD 精神補充
==================
TDD的過程中，在正常情況下，測試總管最多只會存在一個失敗的測試案例。而且這個失敗的測試案例，一定就是剛剛加入的 scenario。也就是代表著目前 production code 要加進去支援的新功能。

只要測試總管存在一個以上失敗的測試案例，就代表異常，代表被相互影響到。

一次只新增一個 scenario，因為 production code "尚未支援" 這個新的 scenario，所以測試結果為紅燈。透過紅燈的標示，可以很清楚地定義出，production code的目標，就是要通過這個紅燈，讓它變成綠燈，就代表 production code 在這個新的 scenario 底下可以正常運作。而且 production code 之前支援的所有 scenarios 也都如預期正常運作。

一次只新增一個失敗的測試案例，目的就是為了讓開發人員在調整 production code 時可以完全聚焦在眼前這個新的 scenario。過去已經支援的 scenario 都不用再考慮，只需要找到新的 scenario 應該從目前 production code 的哪一個商業邏輯岔出分支。

怎麼調整 production code 來通過眼前要新增的這個 scenario 呢？Baby step！這是開發人員第二個常見的關卡，明明我就知道後面的需求，在這邊如果怎麼寫，我就可以一次滿足好幾個需求，為什麼我要傻傻地用 baby step 來寫看起來很愚蠢的 production code 呢？ 因為用最少、最簡單、最直覺的方式來通過測試案例滿足需求，你新增程式碼的程度行數最少，或是最直覺，別忘了，我們這次只 focus 在這一次異動的程式碼。用越少、越簡單、越直覺地方式通過眼前這個測試案例，等等的重構動作就越輕鬆。因為你這次異動的程式碼相當少，重構當然就顯得輕鬆。

也因為每次只 focus 在一個 scenario 與之前所有 scenario 不同的地方，並且用最簡單的方式滿足這一個新的 scenario，所以可以有效地避免 over-design 的情況發生。先有 code，再重構，可以有效滿足兩個目的：

1. 即時交付
2. 順手整理 production code 與清理 tech debt

也因為你的每一行 production code 都滿足著某一個 scenario，因為你的每一行 production code 都有著代表著 scenario 是否正常運作的測試案例保護，所以重構起來毫無風險。也因為你這次異動 production code 程式碼的幅度很小，所以重構的速度快、難度低、範圍小。

PS: 補充，每一個 production code 的分支，都是被某一個獨特有代表性的 scenario 切出來的。
