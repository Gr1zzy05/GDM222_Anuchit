using Assignment02.StudentSolution;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Solution
{
    public class OOPExit : Identity
    {
        public GameObject YouWin;
        public ItemData keyToExit;
        public int requiredKeyAmount;
        public Leaderboard leaderboard;
        public override void Hit(Identity hitBy)
        {
            if (hitBy is OOPPlayer) {
                OOPPlayer player = (OOPPlayer)hitBy;
                if (player.inventory.HasItem(keyToExit, requiredKeyAmount)) {
                    YouWin.SetActive(true);

                    player.inventory.UseItem(keyToExit, requiredKeyAmount);
                    player.UpdatePosition(this.positionX, this.positionY);
                    mapGenerator.playerScript.enabled = false;

                    Debug.Log("You win");
                }
            }
            
        }

        int CalculateScore(OOPPlayer player)
        {
            int score = (int)((player.energy * 100) / Time.time);
            return score;
        }
    }
}