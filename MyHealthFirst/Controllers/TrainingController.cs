﻿using AutoMapper;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
            private readonly ProjectDBContext _context;
            private readonly IMapper _mapper;
            public TrainingController(ProjectDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            // GET: api/Training
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Training>>> GetTrainings()
            {
                if (_context.Trainings == null)
                {
                    return NotFound();
                }
                return await _context.Trainings.Include(t => t.Exercises).ToListAsync();
            }

            // GET: api/Training/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Training>> GetTraining(int id)
            {
                var training = await _context.Trainings
                    .Include(t => t.Exercises)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (training == null)
                {
                    return NotFound();
                }

                return training;
            }
        [HttpPost]
        public async Task<ActionResult> Post(int TrainerId, TrainingDTO trainingDTO)
        {
            var training = _mapper.Map<Training>(trainingDTO);
            training.TrainerId = TrainerId;

            if (training.Exercises is not null)
            {
                foreach (var exercise in training.Exercises)
                {
                    _context.Entry(exercise).State = EntityState.Unchanged;
                }
            }

            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Training/5
        [HttpPut("{id}")]
            public async Task<IActionResult> PutTraining(int id, TrainingDTO trainingDTO)
            {

                var training = await _context.Trainings
                   .Include(t => t.Trainer)
                   .Include(t => t.Exercises)
                   .FirstOrDefaultAsync(n => n.Id == id);

                if (training == null)
                {
                    return NotFound();
                }

                _mapper.Map(trainingDTO, training);

                _context.Entry(training).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok();

            }

            // DELETE: api/Training/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTraining(int id)
            {
                if (_context.Trainings == null)
                {
                    return NotFound();
                }
            var training = await _context.Trainings.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }
            _context.Trainings.Remove(training);

                await _context.SaveChangesAsync();

                return NoContent();
            }


        }
    }