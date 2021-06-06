﻿using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GameControllerAPI : ControllerBase
    {
        [HttpGet("games/{id}")]
        public ActionResult<Game> Index(string id)
        {
            GameSecurityDAO service = new GameSecurityDAO();
            int searchId;

            if (Int32.TryParse(id, out searchId))
            {
                Game result = service.FindById(searchId);
                if (result == null || result.Id != searchId) return NotFound(id);
                return result;
            }
            return NotFound(id);
        }

        [HttpPost("games/{id}/resume")]
        public ActionResult Resume(string id)
        {
            GameSecurityDAO service = new GameSecurityDAO();
            int searchId;
            if (Int32.TryParse(id, out searchId))
            {
                Game result = service.ResumeGame(searchId);
                if (result == null || result.Id != searchId) return NotFound(id);
                return Ok(result);
            }
            return NotFound(id);
        }

        [HttpPost("games/{id}/pause")]
        public ActionResult Pause(Game game)
        {
            GameSecurityDAO service = new GameSecurityDAO();
            bool result = service.PauseGame(game);
            if (!result) return NotFound(game);
            return Ok("Successfully paused the game: " + game.Id);
        }
    }
}
