using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _service;
        private readonly IWorkflowTemplateService _templateService;
        public WorkflowController(IWorkflowService service, IWorkflowTemplateService templateService)
        {
            _service = service;
            _templateService = templateService;
        }

        [HttpPost("initialize")]
        public async Task<IActionResult> Initialize(
            [FromBody] InitializeWorkflowRequestDto request)
        {
            await _service.InitializeAsync(request);
            return Ok();
        }

        [HttpGet("{transactionId}/actions")]
        public async Task<ActionResult<WorkflowAvailableActionsDto>> GetActions(
            string transactionId,
            [FromQuery] Guid roleId)
        {
            var result = await _service.GetAvailableActionsAsync(transactionId, roleId);
            return Ok(result);
        }

        [HttpPost("execute")]
        public async Task<IActionResult> Execute(
            [FromBody] ExecuteWorkflowActionRequestDto request)
        {
            await _service.ExecuteActionAsync(request);
            return Ok();
        }

        [HttpGet("{transactionId}")]
        public async Task<ActionResult<WorkflowInstanceDto>> GetInstance(
            string transactionId)
        {
            var result = await _service.GetInstanceAsync(transactionId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("templates")]
        public async Task<IActionResult> Save([FromBody] WorkflowTemplateCreateDto dto)
        {
            var id = await _templateService.SaveAsync(dto);
            return Ok(new { id });
        }
    }
}
